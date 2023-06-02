using FoodieSite.API.DTOs.Request;
using FoodieSite.API.DTOs.Response;
using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Queries.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemMasterController : ControllerBase
    {
        private readonly IItemMasterCommands objItemMasterCommands;
        private readonly IItemMasterQueries objItemMasterQueries;

        public ItemMasterController(IItemMasterCommands _objItemMasterCommands, IItemMasterQueries _objItemMasterQueries)
        {
            objItemMasterCommands = _objItemMasterCommands;
            objItemMasterQueries = _objItemMasterQueries;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(
                    await objItemMasterQueries.GetAll()); // convert into response DTO 

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        [HttpGet]
        [Route("getById/{Id}")]
        public async Task<IActionResult> GetByRestaurantId(Guid Id)
        {
            try
            {
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(
                    await objItemMasterQueries.GetById(Id)); // convert into response DTO

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] ItemMasterDTO objDTO)
        {
            try
            {
                if (objDTO == null)
                    return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Object is null.", StatusCode = 500 });

                var response = await objItemMasterCommands.Insert(
                    ItemMasterDTO.ToItemMasterModel(objDTO)); // pass to command

                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response);  // convert into DTO

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] ItemMasterDTO objDTO)
        {
            try
            {
                if (objDTO == null)
                    return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Object is null.", StatusCode = 500 });

                var response = await objItemMasterCommands.Update(
                    ItemMasterDTO.ToItemMasterModel(objDTO)); // pass to command

                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response);  // convert into DTO

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        [HttpDelete]
        [Route("delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(
                    await objItemMasterCommands.Delete(Id));  // pass to command

                return StatusCode(responseDTO.StatusCode, responseDTO);  // convert into DTO
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }
    }
}
