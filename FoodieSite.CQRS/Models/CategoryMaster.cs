/* 
 * Summary. This is a CategoryMaster model for handling CategoryMaster in the database
 *
 * Date: 05/30/2023
 * Author: Abdullah Fiaz
 * Company: How To Pakistan
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    /// <summary>
	///  This is a CategoryMaster model for handling CategoryMaster in the database
	/// </summary>
    public class CategoryMaster : BaseEntity
    {
        /// <summary>
		/// Category Full Name
		/// </summary>
        [Required]
        [Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
		/// Category Description
		/// </summary>
        [Required]
        [Column("description", TypeName = "nvarchar(250)")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
		/// FK Store Master Id
		/// </summary>
        [Required]
        [Column("store_id")]
        public Guid StoreId { get; set; } = Guid.Empty;

        // Navigations
        [ForeignKey("StoreId")]
        public virtual StoreMaster? StoreMaster { get; set; }
        public virtual IEnumerable<ItemMaster>? ItemMaster { get; set; }

        /// <summary>
		/// Default contsructor of the class.
		/// </summary>
		public CategoryMaster() : base()
        {

        }

        /// <summary>
		/// Contructor with parameters
		/// </summary>
		/// <param name="name">The name of the category.</param>
		/// <param name="description">The description of the category.</param>
		/// <param name="storeId">The associated store id.</param>
		public CategoryMaster(string name, string description,
                           Guid storeId) : base(Guid.NewGuid())
        {
            Name = name;
            Description = description;
            StoreId = storeId;
        }
    }
}
