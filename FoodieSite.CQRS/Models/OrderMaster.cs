/* 
 * Summary. This is a OrderMaster model for handling OrderMaster in the database
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
using System.Xml.Linq;

namespace FoodieSite.CQRS.Models
{
    /// <summary>
	///  This is a OrderMaster model for handling OrderMaster in the database
	/// </summary>
    public class OrderMaster : BaseEntity
    {
        /// <summary>
		/// Order Invoice No
		/// </summary>
        [Required]
        [Column("invoice_no", TypeName = "nvarchar(100)")]
        public string InvoiceNo { get; set; } = string.Empty;

        /// <summary>
		/// FK Store Master Id
		/// </summary>
        [Required]
        [Column("store_id")]
        public Guid StoreId { get; set; } = Guid.Empty;

        /// <summary>
		/// FK Customer Master Id
		/// </summary>
        [Required]
        [Column("customer_id")]
        public Guid CustomerId { get; set; } = Guid.Empty;


        //Navigations
        [ForeignKey("StoreId")]
        public virtual StoreMaster? StoreMaster { get; set; }

        [ForeignKey("CustomerId")]
        public virtual CustomerMaster? CustomerMaster { get; set; }

        public virtual IEnumerable<OrderStatus>? OrderStatus { get; set; }

        /// <summary>
		/// Default contsructor of the class.
		/// </summary>
		public OrderMaster() : base()
        {

        }

        /// <summary>
		/// Contructor with parameters
		/// </summary>
		/// <param name="invoiceNo">The invoice no of the order.</param>
        /// <param name="storeId">The associated store id.</param>
		/// <param name="customerId">The associated customer id.</param>
		public OrderMaster(string invoiceNo, Guid storeId, 
            Guid customerId) : base(Guid.NewGuid())
        {
            InvoiceNo = invoiceNo;
            StoreId = storeId;
            CustomerId = customerId;
        }
    }
}
