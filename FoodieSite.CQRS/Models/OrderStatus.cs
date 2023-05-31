/* 
 * Summary. This is a OrderStatus model for handling OrderStatus in the database
 *
 * Date: 05/30/2023
 * Author: Abdullah Fiaz
 * Company: How To Pakistan
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
    /// <summary>
    ///  This is a OrderStatus model for handling OrderStatus in the database
    /// </summary>
    public class OrderStatus : BaseEntity
    {
        /// <summary>
		/// Order Status
		/// </summary>
        [Required]
        [Column("status", TypeName = "int")]
        public int Status { get; set; }

        /// <summary>
		/// FK Order Master Id
		/// </summary>
        [Required]
        [Column("order_id")]
        public Guid OrderId { get; set; } = Guid.Empty;

        // Navigation
        [ForeignKey("OrderId")]
        public virtual OrderMaster? OrderMaster { get; set; }

        /// <summary>
		/// Default contsructor of the class.
		/// </summary>
		public OrderStatus() : base()
        {

        }

        /// <summary>
		/// Contructor with parameters
		/// </summary>
		/// <param name="status">The status of the order.</param>
        /// <param name="orderId">The associated order id.</param>
		public OrderStatus(int status, Guid orderId) : base(Guid.NewGuid())
        {
            Status = status;
            OrderId = orderId;
        }
    }
}
