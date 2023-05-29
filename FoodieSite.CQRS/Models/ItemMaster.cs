using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    public class ItemMaster:BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal SalePrice { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public Guid CategoryId { get; set; } //foreign key

        [ForeignKey("CategoryId")]
        public virtual CategoryMaster CategoryMaster { get; set; }
    }
}
