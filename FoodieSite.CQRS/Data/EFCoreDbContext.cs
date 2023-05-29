using FoodieSite.CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Data
{
    public class EFCoreDbContext : DbContext
    {
        public EFCoreDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<RestaurantMaster> tblRestaurantMaster { get; set; }
        public DbSet<StoreMaster> tblStoreMaster { get; set; }
        public DbSet<CategoryMaster> tblCategoryMaster { get; set; }
        public DbSet<ItemMaster> tblItemMaster { get; set; }
        public DbSet<CustomerMaster> tblCustomerMaster { get; set; }
        public DbSet<OrderMaster> tblOrderMaster { get; set; }
        public DbSet<OrderDetails> tblOrderDetails { get; set; }
        public DbSet<OrderStatus> tblOrderStatus { get; set; }
        public DbSet<PaymentMaster> tblPaymentMaster { get; set; }
    }
}
