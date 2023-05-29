using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    public class CustomerMaster : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string ContactNumber1 { get; set; }

        [MaxLength(100)]
        public string ContactNumber2 { get; set; }

        //Navigation
        public virtual IEnumerable<OrderMaster> OrderMaster { get; set; }
    }
}
