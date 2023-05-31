using AutoMapper;
using FoodieSite.API.DTOs.Response;
using FoodieSite.API.ExtensionMethods;
using FoodieSite.CQRS.Models;

namespace FoodieSite.API.DTOs.Request
{
    public class CategoryMasterDTO : BaseEntityDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? StoreId { get; set; }

        public static CategoryMaster ToCategoryMasterModel(CategoryMasterDTO storeDTO)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryMasterDTO, CategoryMaster>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();
            var obj = mapper.Map<CategoryMasterDTO, CategoryMaster>(storeDTO);

            return obj;
        }
        public static CategoryMasterDTO ToCategoryMasterDTO(CategoryMaster model)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryMaster, CategoryMasterDTO>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();
            var objDTO = mapper.Map<CategoryMaster, CategoryMasterDTO>(model);

            return objDTO;
        }
    }
}
