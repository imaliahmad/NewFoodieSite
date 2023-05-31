/* 
 * Summary. This is a CustomerMaster model for handling CustomerMaster in the database
 *
 * Date: 05/30/2023
 * Author: Abdullah Fiaz
 * Company: How To Pakistan
 * 
 */
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
	///  This is a CustomerMaster model for handling CustomerMaster in the database
	/// </summary>
    public class CustomerMaster : BaseEntity
    {
        /// <summary>
		/// Customer Full Name
		/// </summary>
        [Required]
        [Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
		/// Item address
		/// </summary>
        [Required]
        [Column("address", TypeName = "nvarchar(350)")]
        public string Address { get; set; } = string.Empty;

        /// <summary>
		/// Customer City
		/// </summary>
        [Required]
        [Column("city", TypeName = "nvarchar(100)")]
        public string City { get; set; } = string.Empty;


        /// <summary>
        /// Customer ContactNumber1
        /// </summary>
        [Required]
        [Column("contact_number_1", TypeName = "nvarchar(100)")]
        public string ContactNumber1 { get; set; } = string.Empty;

        /// <summary>
        /// Customer ContactNumber2
        /// </summary>
        [Column("contact_number_2", TypeName = "nvarchar(100)")]
        public string ContactNumber2 { get; set; } = string.Empty;

        //Navigation
        public virtual IEnumerable<OrderMaster>? OrderMaster { get; set; }

        /// <summary>
		/// Default contsructor of the class.
		/// </summary>
		public CustomerMaster() : base()
        {

        }

        /// <summary>
		/// Contructor with parameters
		/// </summary>
		/// <param name="name">The name of the customer.</param>
        /// <param name="address">The address of the customer.</param>
		/// <param name="city">The city of the customer.</param>
		/// <param name="contactNumber1">The contactNumber1 of the customer.</param>
        /// <param name="contactNumber2">The contactNumber2 of the customer.</param>
		public CustomerMaster(string name, string address, string city, 
            string contactNumber1, string contactNumber2) : base(Guid.NewGuid())
        {
            Name = name;
            Address = address;
            City = city;
            ContactNumber1 = contactNumber1;
            ContactNumber2 = contactNumber2;
        }
    }
}
