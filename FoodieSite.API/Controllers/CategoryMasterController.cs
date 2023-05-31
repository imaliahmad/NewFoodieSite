/* 
 * Summary. This is a CategoryMaster api controller for handling and managing CategoryMaster.
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
    public class CategoryMasterController : ControllerBase
    {
        private readonly ICategoryMasterCommands objCategoryMasterCommands;
        private readonly ICategoryMasterQueries objCategoryMasterQueries;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMasterController"/> class.
        /// </summary>
        /// <param name="_objCategoryMasterCommands">The store master commands instance.</param>
        /// <param name="_objCategoryMasterQueries">The store master queries instance.</param>
        public CategoryMasterController(ICategoryMasterCommands _objCategoryMasterCommands, ICategoryMasterQueries _objCategoryMasterQueries)
        {
            objCategoryMasterCommands = _objCategoryMasterCommands;
            objCategoryMasterQueries = _objCategoryMasterQueries;
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
                    await objCategoryMasterQueries.GetAll());

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
                    await objCategoryMasterQueries.GetById(Id));

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
        public async Task<IActionResult> Create([FromBody] CategoryMasterDTO objDTO)
        {
            try
            {
                if (objDTO == null)
                    return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Object is null.", StatusCode = 500 });

                var response = await objCategoryMasterCommands.Insert(
                    CategoryMasterDTO.ToCategoryMasterModel(objDTO));

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
        public async Task<IActionResult> Update([FromBody] CategoryMasterDTO objDTO)
        {
            try
            {
                if (objDTO == null)
                    return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Object is null.", StatusCode = 500 });

                var response = await objCategoryMasterCommands.Update(
                    CategoryMasterDTO.ToCategoryMasterModel(objDTO));

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
                    await objCategoryMasterCommands.Delete(Id));

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
