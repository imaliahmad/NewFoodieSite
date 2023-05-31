/* 
 * Summary. This is a ItemMaster model for handling ItemMaster in the database
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
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    /// <summary>
	///  This is a ItemMaster model for handling ItemMaster in the database
	/// </summary>
    public class ItemMaster:BaseEntity
    {
        /// <summary>
		/// Item Full Name
		/// </summary>
        [Required]
        [Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
		/// Item SalePrice
		/// </summary>
        [Required]
        [Column("sale_price", TypeName = "decimal(18, 2)")]
        public decimal SalePrice { get; set; } = 0;

        /// <summary>
		/// Item Description
		/// </summary>
        [Required]
        [Column("description", TypeName = "nvarchar(250)")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
		/// FK Category Master Id
		/// </summary>
        [Column("category_id")]
        public Guid CategoryId { get; set; } = Guid.Empty;

        //Navigations
        [ForeignKey("CategoryId")]
        public virtual CategoryMaster? CategoryMaster { get; set; }

        /// <summary>
		/// Default contsructor of the class.
		/// </summary>
		public ItemMaster() : base()
        {

        }

        /// <summary>
		/// Contructor with parameters
		/// </summary>
		/// <param name="name">The name of the item.</param>
        /// <param name="salePrice">The salePrice of the item.</param>
		/// <param name="description">The description of the item.</param>
		/// <param name="categoryId">The associated category id.</param>
		public ItemMaster(string name, decimal salePrice, string description,
                           Guid categoryId) : base(Guid.NewGuid())
        {
            Name = name;
            SalePrice = salePrice;
            Description = description;
            CategoryId = categoryId;
        }
    }
}
