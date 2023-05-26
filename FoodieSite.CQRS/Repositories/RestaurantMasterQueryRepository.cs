using FoodieSite.CQRS.Data;
using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Repositories
{
	public class RestaurantMasterQueryRepository : IRestaurantMasterQueryRepository
	{
		private readonly EFCoreDbContext context;
		public RestaurantMasterQueryRepository(EFCoreDbContext _context)
		{
			context = _context;
		}
		public async Task<JsonResponse> GetAll()
		{
			var list = await context.RestaurantMaster.ToListAsync();
			return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
		}

		public async Task<JsonResponse> GetByCompanyId(Guid id)
		{
			var obj = new RestaurantMaster(); // await context.RestaurantMaster.Where(x => x.CompanyId == id).ToListAsync();
			if (obj == null)
			{
				return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
			}

			return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
		}

		public async Task<JsonResponse> GetByRestaurantId(Guid id)
		{
			var obj = await context.RestaurantMaster.FindAsync(id);
			if (obj == null)
			{
				return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
			}

			return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
		}
	}
}
