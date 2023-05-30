/* 
 * Summary. This is a RestaurantMaster model for handling RestaurantMaster in the database
 *
 * Date: 05/30/2023
 * Author: Ali Ahmed
 * Company: How To Pakistan
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
	/// <summary>
	///  This is a RestaurantMaster model for handling RestaurantMaster in the database
	/// </summary>
	public class RestaurantMaster : BaseEntity
	{
		/// <summary>
		/// Restaurant Full Name
		/// </summary>
		[Required]
		[Column("name", TypeName = "nvarchar(max)")]
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Restaurant Code
		/// </summary>
		[Column("restaurant_code", TypeName = "nvarchar(350)")]
		public string RestaurantCode { get; set; } = string.Empty;

		/// <summary>
		/// Restaurant Address
		/// </summary>
		[Required]
		[Column("address", TypeName = "nvarchar(max)")]
		public string Address { get; set; } = string.Empty;


		/// <summary>
		/// Restaurant City
		/// </summary>
		[Required]
		[Column("city", TypeName = "nvarchar(250)")]
		public string City { get; set; } = string.Empty;

		/// <summary>
		/// Restaurant First Contact No 
		/// </summary>
		[Required]
		[Column("contact_number_1", TypeName = "nvarchar(250)")]
		public string ContactNumber1 { get; set; } = string.Empty;

		/// <summary>
		/// Restaurant Second Contact No
		/// </summary>
		[Column("contact_number_2", TypeName = "nvarchar(250)")]
		public string ContactNumber2 { get; set; } = string.Empty;

		/// <summary>
		/// Restaurant email
		/// </summary>
		[Column("email", TypeName = "nvarchar(350)")]
		[MaxLength(100)]
		public string Email { get; set; } = string.Empty;


		// === Navigations === 
		public virtual IEnumerable<StoreMaster>? StoreMaster { get; set; }


		/// <summary>
		/// Default contructor of the class.
		/// </summary>
		public RestaurantMaster() : base()
		{
			
		}

		/// <summary>
		/// Contructor with parameters
		/// </summary>
		/// <param name="name">The name of the restaurant.</param>
		/// <param name="restaurantCode">The code of the restaurant.</param>
		/// <param name="address">The address of the restaurant.</param>
		/// <param name="city">The city of the restaurant.</param>
		/// <param name="contactNumber1">The first contact number  of the restaurant.</param>
		/// <param name="contactNumber2">The second contact number  of the restaurant.</param>
		/// <param name="email">The email of the restaurant.</param>
		public RestaurantMaster(string name, string restaurantCode,
								string address, string city, string contactNumber1,
								string contactNumber2, string email) : base(Guid.NewGuid())
		{
			Name = name;
			RestaurantCode = restaurantCode;
			Address = address;
			City = city;
			ContactNumber1 = contactNumber1;
			ContactNumber2 = contactNumber2;
			Email = email;
		}
	}
}
