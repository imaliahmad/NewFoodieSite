using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    public class StoreMaster : BaseEntity
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

        public Guid RestaurantId { get; set; } //foreign key

        [ForeignKey("RestaurantId")]
        public virtual RestaurantMaster RestaurantMaster { get; set; }

        //Navigations
        public virtual IEnumerable<CategoryMaster> CategoryMaster { get; set; }
        public virtual IEnumerable<OrderMaster> OrderMaster { get; set; }
    }
}
