using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    public class PaymentMaster : BaseEntity
    {
        public string Type { get; set; }

        public Guid OrderId { get; set; } //foreign key

        [ForeignKey("OrderId")]
        public virtual OrderMaster Order { get; set; }
    }
}
