using FoodieSite.CQRS.Data;
using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories
{
	public class RestaurantMasterCommandRepository : IRestaurantMasterCommandRepository
	{
		private readonly EFCoreDbContext context;
		public RestaurantMasterCommandRepository(EFCoreDbContext _context)
		{
			context = _context;
		}
		public async Task<JsonResponse> Delete(Guid id) //200
		{
			var obj = await context.RestaurantMaster.FindAsync(id);
			if (obj == null)
			{
				return new JsonResponse() { IsSuccess = false, Message = "Record not found.", StatusCode = 404 };
			}

			context.RestaurantMaster.Remove(obj);
			await context.SaveChangesAsync();

			return new JsonResponse() { IsSuccess = true, Message = "Record deleted successfully.", StatusCode = 200 };
		}

		public async Task<JsonResponse> Insert(RestaurantMaster obj)
		{
			context.RestaurantMaster.Add(obj);
			await context.SaveChangesAsync();

			return new JsonResponse() { IsSuccess = true, Data = obj, Message = "Record saved successfully.", StatusCode = 200 };

		}

		public async Task<JsonResponse> Update(RestaurantMaster obj)
		{
			context.RestaurantMaster.Update(obj);
			await context.SaveChangesAsync();

			return new JsonResponse() { IsSuccess = true, Message = "Record updated successfully.", StatusCode = 200 };

		}
	}
}
