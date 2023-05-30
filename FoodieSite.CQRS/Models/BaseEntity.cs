using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Models
{
	public class BaseEntity
	{
		[Key]
		public Guid Id { get; set; }

		public bool IsActive { get; set; }
		public DateTime CreatedDate { get; set; }
		public Guid CreatedBy { get; set; }

		public Guid? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }

		public BaseEntity()
		{

		}
		public BaseEntity(Guid id)
		{
			Id = id;
		}

		public BaseEntity(Guid id, bool isActive, DateTime createdDate,
						  Guid createdBy, Guid? modifiedBy, DateTime? modifiedDate)
		{
			Id = id;
			IsActive = isActive;
			CreatedDate = createdDate;
			CreatedBy = createdBy;
			ModifiedBy = modifiedBy;
			ModifiedDate = modifiedDate;
		}
	}
}
