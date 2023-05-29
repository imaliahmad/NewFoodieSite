using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    public class CategoryMaster : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }


        public Guid StoreId { get; set; } //foreign key

        [ForeignKey("StoreId")]
        public virtual StoreMaster StoreMaster { get; set; }

        //Navigation
        public virtual IEnumerable<ItemMaster> ItemMaster { get; set; }
    }
}
