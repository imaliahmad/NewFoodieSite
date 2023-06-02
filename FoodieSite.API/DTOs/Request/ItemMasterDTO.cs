using AutoMapper;
using FoodieSite.API.DTOs.Response;
using FoodieSite.API.ExtensionMethods;
using FoodieSite.CQRS.Models;

namespace FoodieSite.API.DTOs.Request
{
    public class ItemMasterDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public static ItemMaster ToItemMasterModel(ItemMasterDTO storeDTO)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemMasterDTO, ItemMaster>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();
            var obj = mapper.Map<ItemMasterDTO, ItemMaster>(storeDTO);

            return obj;
        }
        public static ItemMasterDTO ToItemMasterDTO(ItemMaster model)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemMaster, ItemMasterDTO>();
                cfg.IgnoreUnmapped();
            });

            IMapper mapper = config.CreateMapper();
            var objDTO = mapper.Map<ItemMaster, ItemMasterDTO>(model);

            return objDTO;
        }
    }
}
