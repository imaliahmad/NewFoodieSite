using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    public class OrderMaster : BaseEntity
    {
        public string InvoiceNo { get; set; }

        public Guid StoreId { get; set; } //foreign key
        public Guid CustomerId { get; set; } //foreign key


        [ForeignKey("StoreId")]
        public virtual StoreMaster StoreMaster { get; set; }

        [ForeignKey("CustomerId")]
        public virtual CustomerMaster CustomerMaster { get; set; }

        //Navigations
        public virtual IEnumerable<OrderStatus> OrderStatus { get; set; }
    }
}
