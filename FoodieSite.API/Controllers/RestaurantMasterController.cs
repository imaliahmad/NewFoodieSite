/* 
 * Summary. This is a RestaurantMaster api controller for handling and managing RestaurantMaster.
 *
 * Date: 05/30/2023
 * Author: Ali Ahmed
 * Company: How To Pakistan
 * 
 */
using FoodieSite.API.DTOs.Response;
using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Queries.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieSite.API.Controllers
{
	/// <summary>
	/// This is a RestaurantMaster api controller for handling and managing RestaurantMaster.
	/// </summary>
	[Route("api/[controller]")]
    [ApiController]
    public class RestaurantMasterController : ControllerBase
    {
		/// <summary>
		/// The RestaurantMaster commands for handling the restaurant get requests 
		/// </summary>
		private readonly IRestaurantMasterCommands objRestaurantMasterCommands;

		/// <summary>
		/// The RestaurantMaster queries for handling the restaurant post requests 
		/// </summary>
		private readonly IRestaurantMasterQueries objRestaurantMasterQueries;


		/// <summary>
		/// Constructor with parameters
		/// </summary>
		/// <param name="_objRestaurantMasterCommands">This field contains the command instance.</param>
		/// <param name="_objRestaurantMasterQueries">This field contains the query instance.</param>
		public RestaurantMasterController(IRestaurantMasterCommands _objRestaurantMasterCommands, IRestaurantMasterQueries _objRestaurantMasterQueries)
        {
            objRestaurantMasterCommands = _objRestaurantMasterCommands;
            objRestaurantMasterQueries = _objRestaurantMasterQueries;
        }

        /// <summary>
        /// Read all the restaurants in the database.
        /// </summary>
        /// <returns>HTTP response containing the list of restaurants.</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(
					                         await objRestaurantMasterQueries.GetAll()); 

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        /// <summary>
        /// Gets a restaurant by its ID.
        /// </summary>
        /// <param name="Id">The ID of the restaurant master.</param>
        /// <returns>HTTP response containing the restaurant master.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public async Task<IActionResult> GetByRestaurantId(Guid Id)
        {
            try
            {
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(
									   await objRestaurantMasterQueries.GetById(Id));

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

                var response = await objRestaurantMasterCommands.Update(
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
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(
									  await objRestaurantMasterCommands.Delete(Id)); // convert into DTO

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
