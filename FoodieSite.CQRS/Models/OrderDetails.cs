using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    public  class OrderDetails:BaseEntity
    {

        public int Quantity { get; set; }

        public Guid OrderId { get; set; } //foreign key
        public Guid ItemId { get; set; } //foreign key


        [ForeignKey("OrderId")]
        public virtual OrderMaster OrderMaster { get; set; }

        [ForeignKey("ItemId")]
        public virtual ItemMaster ItemMaster { get; set; }

    }
}
