/* 
 * Summary. This is a StoreMaster api controller for handling and managing StoreMaster.
 *
 * Date: 05/30/2023
 * Author: Abdullah Fiaz
 * Company: How To Pakistan
 * 
 */
using FoodieSite.API.DTOs.Request;
using FoodieSite.API.DTOs.Response;
using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Queries.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FoodieSite.API.Controllers
{
    /// <summary>
    /// Controller for managing store master operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StoreMasterController : ControllerBase
    {
        private readonly IStoreMasterCommands objStoreMasterCommands;
        private readonly IStoreMasterQueries objStoreMasterQueries;

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreMasterController"/> class.
        /// </summary>
        /// <param name="_objStoreMasterCommands">The store master commands instance.</param>
        /// <param name="_objStoreMasterQueries">The store master queries instance.</param>
        public StoreMasterController(IStoreMasterCommands _objStoreMasterCommands, IStoreMasterQueries _objStoreMasterQueries)
        {
            objStoreMasterCommands = _objStoreMasterCommands;
            objStoreMasterQueries = _objStoreMasterQueries;
        }

        /// <summary>
        /// Retrieves all store masters.
        /// </summary>
        /// <returns>HTTP response containing the list of store masters.</returns>
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(
                    await objStoreMasterQueries.GetAll());

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        /// <summary>
        /// Retrieves a store master by its ID.
        /// </summary>
        /// <param name="Id">The ID of the store master.</param>
        /// <returns>HTTP response containing the store master.</returns>
        [HttpGet]
        [Route("getById/{Id}")]
        public async Task<IActionResult> GetByRestaurantId(Guid Id)
        {
            try
            {
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(
                    await objStoreMasterQueries.GetById(Id));

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        /// <summary>
        /// Creates a new store master.
        /// </summary>
        /// <param name="objDTO">The DTO containing the store master details.</param>
        /// <returns>HTTP response containing the result of the create operation.</returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] StoreMasterDTO objDTO)
        {
            try
            {
                if (objDTO == null)
                    return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Object is null.", StatusCode = 500 });

                var response = await objStoreMasterCommands.Insert(
                    StoreMasterDTO.ToStoreMasterModel(objDTO));

                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response);

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        /// <summary>
        /// Updates an existing store master.
        /// </summary>
        /// <param name="objDTO">The DTO containing the updated store master details.</param>
        /// <returns>HTTP response containing the result of the update operation.</returns>
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] StoreMasterDTO objDTO)
        {
            try
            {
                if (objDTO == null)
                    return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Object is null.", StatusCode = 500 });

                var response = await objStoreMasterCommands.Update(
                    StoreMasterDTO.ToStoreMasterModel(objDTO));

                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response);

                return StatusCode(responseDTO.StatusCode, responseDTO);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
            }
        }

        /// <summary>
        /// Deletes a store master by its ID.
        /// </summary>
        /// <param name="Id">The ID of the store master to delete.</param>
        /// <returns>HTTP response containing the result of the delete operation.</returns>
        [HttpDelete]
        [Route("delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var responseDTO = JsonResponseDTO.ToJsonResponseDTO(
                    await objStoreMasterCommands.Delete(Id));

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
