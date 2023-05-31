using AutoMapper;
using FoodieSite.API.DTOs.Response;
using FoodieSite.API.ExtensionMethods;
using FoodieSite.CQRS.Models;

namespace FoodieSite.API.DTOs.Request
{
    public class StoreMasterDTO : BaseEntityDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ContactNumber1 { get; set; }
        public string? ContactNumber2 { get; set; }
        public Guid? RestaurantId { get; set; }  


        public static StoreMaster ToStoreMasterModel(StoreMasterDTO storeDTO)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StoreMasterDTO, StoreMaster>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();
            var obj = mapper.Map<StoreMasterDTO, StoreMaster>(storeDTO);

            return obj;
        }
        public static StoreMasterDTO ToStoreMasterDTO(StoreMaster model)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StoreMaster, StoreMasterDTO>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();
            var objDTO = mapper.Map<StoreMaster, StoreMasterDTO>(model);

            return objDTO;
        }
    }
}
