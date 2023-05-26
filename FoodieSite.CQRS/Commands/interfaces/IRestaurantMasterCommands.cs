using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Commands.interfaces
{
	public interface IRestaurantMasterCommands
	{
		Task<JsonResponse> Insert(RestaurantMaster obj);
		Task<JsonResponse> Update(RestaurantMaster obj);
		Task<JsonResponse> Delete(Guid id);
	}
}
