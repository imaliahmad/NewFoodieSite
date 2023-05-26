using FoodieSite.API.DTOs.Response;
using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Queries.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieSite.API.Controllers
{
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

		[HttpGet]
		[Route("getByCompanyId/{cId}")]
		public async Task<IActionResult> getByCompanyId(Guid cId)
		{
			try
			{
				var response = await objRestaurantMasterQueries.GetByCompanyId(cId);
				var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response); //convert into DTO

				if (responseDTO.IsSuccess == false && response.StatusCode == 404) //Not Found
				{
					return NotFound(responseDTO);
				}

				return Ok(responseDTO);
			}
			catch (Exception ex)
			{
				var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
				return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
			}
		}

		[HttpGet]
		[Route("getByRestaurantId/{rId}")]
		public async Task<IActionResult> GetByRestaurantId(Guid rId)
		{
			try
			{
				var response = await objRestaurantMasterQueries.GetByRestaurantId(rId);
				var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response); //convert into DTO

				if (responseDTO.IsSuccess == false && response.StatusCode == 404) //Not Found
				{
					return NotFound(responseDTO);
				}

				return Ok(responseDTO);
			}
			catch (Exception ex)
			{
				var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
				return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
			}
		}
		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> Create([FromBody] RestaurantMasterDTO objDTO)
		{
			try
			{
				if (objDTO == null)
					return BadRequest(new JsonResponseDTO()
					{ IsSuccess = false, Message = "Object is null.", StatusCode = 500 });

				var response = await objRestaurantMasterCommands.Insert(
										RestaurantMasterDTO.ToRestaurantMasterModel(objDTO)); // pass to command

				var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response); //convert into DTO 

				return Ok(responseDTO);
			}
			catch (Exception ex)
			{
				var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
				return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
			}
		}

		[HttpPut]
		[Route("update/{rId}")]
		public async Task<IActionResult> Update([FromBody] RestaurantMasterDTO objDTO, Guid rId)
		{
			try
			{
				if (objDTO == null)
					return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Object is null.", StatusCode = 500 });


				if (rId != objDTO.Id)
					return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = "Id and Restaurant Id does not match.", StatusCode = 500 });


				var objCompany = RestaurantMasterDTO.ToRestaurantMasterModel(objDTO); //convert into Model
				var response = await objRestaurantMasterCommands.Update(objCompany); // pass to command

				var responseDTO = JsonResponseDTO.ToJsonResponseDTO(response); //convert into DTO 

				return Ok(responseDTO);
			}
			catch (Exception ex)
			{
				var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
				return BadRequest(new JsonResponseDTO() { IsSuccess = false, Message = msg, StatusCode = 500 });
			}
		}
	}
}
