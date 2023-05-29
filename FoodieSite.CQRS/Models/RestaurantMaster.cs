using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
	public class RestaurantMaster:BaseEntity
	{
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string RestaurantCode { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string ContactNumber1 { get; set; }

        [MaxLength(100)]
        public string ContactNumber2 { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }


        //Navigation
        public virtual IEnumerable<StoreMaster> StoreMaster { get; set; }
    }
}
