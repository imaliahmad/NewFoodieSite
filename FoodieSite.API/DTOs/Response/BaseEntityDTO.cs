namespace FoodieSite.API.DTOs.Response
{
	public class BaseEntityDTO
	{
        public Guid? Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
