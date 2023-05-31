/* 
 * Summary. This is a StoreMaster model for handling StoreMaster in the database
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
	///  This is a StoreMaster model for handling StoreMaster in the database
	/// </summary>
	public class StoreMaster : BaseEntity
    {
		/// <summary>
		/// Store Full Name
		/// </summary>
		[Required]
		[Column("name", TypeName = "nvarchar(max)")]
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Store Address
		/// </summary>
		[Required]
		[Column("address", TypeName = "nvarchar(max)")]
		public string Address { get; set; } = string.Empty;

		/// <summary>
		/// Store City
		/// </summary>
		[Required]
		[Column("city", TypeName = "nvarchar(250)")]
		public string City { get; set; } = string.Empty;


		/// <summary>
		/// Store First Contact No 
		/// </summary>
		[Required]
		[Column("contact_number_1", TypeName = "nvarchar(250)")]
		public string ContactNumber1 { get; set; } = string.Empty;


		/// <summary>
		/// Store Second Contact No
		/// </summary>
		[Column("contact_number_2", TypeName = "nvarchar(250)")]
		public string ContactNumber2 { get; set; } = string.Empty;


        /// <summary>
        /// FK Restaurant Master Id
        /// </summary>
        [Required]
        [Column("restaurant_id")]
		public Guid RestaurantId { get; set; } = Guid.Empty;


		// === Navigations === 
		[ForeignKey("RestaurantId")]
        public virtual RestaurantMaster? RestaurantMaster { get; set; }
        public virtual IEnumerable<CategoryMaster>? CategoryMaster { get; set; }
        public virtual IEnumerable<OrderMaster>? OrderMaster { get; set; }


		/// <summary>
		/// Default contructor of the class.
		/// </summary>
		public StoreMaster():base()
		{

		}

		/// <summary>
		/// Contructor with parameters
		/// </summary>
		/// <param name="name">The name of the store.</param>
		/// <param name="address">The address of the store.</param>
		/// <param name="city">The city of the store.</param>
		/// <param name="contactNumber1">The first contact number  of the store.</param>
		/// <param name="contactNumber2">The second contact number  of the store.</param>
		/// <param name="restaurantId">The associated restaurant id.</param>
		public StoreMaster(string name, string address, string city,
			               string contactNumber1, string contactNumber2, 
						   Guid restaurantId) : base(Guid.NewGuid())
		{
			Name = name;
			Address = address;
			City = city;
			ContactNumber1 = contactNumber1;
			ContactNumber2 = contactNumber2;
			RestaurantId = restaurantId;
		}
	}
}
