using FoodieSite.API.DTOs.Response;
using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Queries.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieSite.API.Controllers
{
    /// <summary>
    /// Controller for managing RestaurantMaster entities.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantMasterController : ControllerBase
    {
        private readonly IRestaurantMasterCommands objRestaurantMasterCommands;
        private readonly IRestaurantMasterQueries objRestaurantMasterQueries;

        public RestaurantMasterController(IRestaurantMasterCommands _objRestaurantMasterCommands, IRestaurantMasterQueries _objRestaurantMasterQueries)
        {
            objRestaurantMasterCommands = _objRestaurantMasterCommands;
            objRestaurantMasterQueries = _objRestaurantMasterQueries;
        }

        /// <summary>
        /// Gets all the restaurant masters.
        /// </summary>
        /// <returns>HTTP response containing the list of restaurant masters.</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await objRestaurantMasterQueries.GetAll();
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response); // convert into DTO

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        /// <summary>
        /// Gets a restaurant master by its ID.
        /// </summary>
        /// <param name="Id">The ID of the restaurant master.</param>
        /// <returns>HTTP response containing the restaurant master.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public async Task<IActionResult> GetByRestaurantId(Guid Id)
        {
            try
            {
                var response = await objRestaurantMasterQueries.GetById(Id);
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response); // convert into DTO

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        /// <summary>
        /// Creates a new restaurant master.
        /// </summary>
        /// <param name="objDTO">The DTO containing the restaurant master details.</param>
        /// <returns>HTTP response containing the result of the create operation.</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] RestaurantMasterDTO objDTO)
        {
            try
            {
                if (objDTO == null)
                    return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Object is null.", StatusCode = 500 });

                var response = await objRestaurantMasterCommands.Insert(
                                        RestaurantMasterDTO.ToRestaurantMasterModel(objDTO)); // pass to command

                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response); // convert into DTO 

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        /// <summary>
        /// Updates an existing restaurant master.
        /// </summary>
        /// <param name="objDTO">The DTO containing the updated restaurant master details.</param>
        /// <returns>HTTP response containing the result of the update operation.</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] RestaurantMasterDTO objDTO)
        {
            try
            {
                if (objDTO == null)
                    return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Object is null.", StatusCode = 500 });

                var objCompany = RestaurantMasterDTO.ToRestaurantMasterModel(objDTO); // convert into Model
                var response = await objRestaurantMasterCommands.Update(objCompany); // pass to command

                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response); // convert into DTO 

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        /// <summary>
        /// Deletes a restaurant master by its ID.
        /// </summary>
        /// <param name="Id">The ID of the restaurant master to delete.</param>
        /// <returns>HTTP response containing the result of the delete operation.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var response = await objRestaurantMasterCommands.Delete(Id);
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response); // convert into DTO

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }
    }
}
