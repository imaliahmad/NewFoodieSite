using AutoMapper;
using FoodieSite.API.ExtensionMethods;
using FoodieSite.CQRS.Models;

namespace FoodieSite.API.DTOs.Response
{
	public class RestaurantMasterDTO:BaseEntityDTO
	{
		public string? RestaurantCode { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }


		public static RestaurantMaster ToRestaurantMasterModel(RestaurantMasterDTO restDTO)
		{

			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<RestaurantMasterDTO, RestaurantMaster>();
				cfg.IgnoreUnmapped();
			});

			IMapper mapper = config.CreateMapper();
			var obj = mapper.Map<RestaurantMasterDTO, RestaurantMaster>(restDTO);

			return obj;
		}
		public static RestaurantMasterDTO ToRestaurantMasterDTO(RestaurantMaster model)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<RestaurantMaster, RestaurantMasterDTO>();
				cfg.IgnoreUnmapped();
			});

			IMapper mapper = config.CreateMapper();
			var objDTO = mapper.Map<RestaurantMaster, RestaurantMasterDTO>(model);

			return objDTO;
		}
	}
}
