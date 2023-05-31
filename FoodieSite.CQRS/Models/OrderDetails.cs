/* 
 * Summary. This is a OrderDetails model for handling OrderDetails in the database
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
    ///  This is a OrderDetails model for handling OrderDetails in the database
    /// </summary>
    public class OrderDetails:BaseEntity
    {
        /// <summary>
		/// Order Quantity
		/// </summary>
        [Required]
        [Column("quantity", TypeName = "int")]
        public int Quantity { get; set; } = 0;

        /// <summary>
		/// FK Order Master Id
		/// </summary>
        [Required]
        [Column("order_id")]
        public Guid OrderId { get; set; } = Guid.Empty;

        /// <summary>
		/// FK Item Master Id
		/// </summary>
        [Required]
        [Column("item_id")]
        public Guid ItemId { get; set; } = Guid.Empty;

        //Navigations
        [ForeignKey("OrderId")]
        public virtual OrderMaster? OrderMaster { get; set; }

        [ForeignKey("ItemId")]
        public virtual ItemMaster? ItemMaster { get; set; }


        /// <summary>
		/// Default contsructor of the class.
		/// </summary>
		public OrderDetails() : base()
        {

        }

        /// <summary>
		/// Contructor with parameters
		/// </summary>
		/// <param name="quantity">The quantity of the order.</param>
        /// <param name="orderId">The associated order id.</param>
		/// <param name="itemId">The associated item id.</param>
		public OrderDetails(int quantity, Guid orderId,
            Guid itemId) : base(Guid.NewGuid())
        {
            Quantity = quantity;
            OrderId = orderId;
            ItemId = itemId;
        }

    }
}
