using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
	public class RestaurantMaster:BaseEntity
	{
		[Key]
		public string? RestaurantCode { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
	}
}
