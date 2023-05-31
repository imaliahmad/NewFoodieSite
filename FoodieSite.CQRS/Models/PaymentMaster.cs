/* 
 * Summary. This is a PaymentMaster model for handling PaymentMaster in the database
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
    ///  This is a PaymentMaster model for handling PaymentMaster in the database
    /// </summary>
    public class PaymentMaster : BaseEntity
    {
        /// <summary>
		/// Payment Type
		/// </summary>
        [Required]
        [Column("type", TypeName = "nvarchar(100)")]
        public string Type { get; set; }

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
		public PaymentMaster() : base()
        {

        }

        /// <summary>
		/// Contructor with parameters
		/// </summary>
		/// <param name="type">The quantity of the type.</param>
        /// <param name="orderId">The associated order id.</param>
		public PaymentMaster(string type, Guid orderId) : base(Guid.NewGuid())
        {
            Type = type;
            OrderId = orderId;
        }
    }
}
