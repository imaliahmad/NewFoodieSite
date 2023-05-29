using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Repositories.interfaces;
using FoodieSite.CQRS.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Commands
{
    /// <summary>
    /// Implementation of the IRestaurantMasterCommands interface for executing commands related to RestaurantMaster entities.
    /// </summary>
    public class RestaurantMasterCommands : IRestaurantMasterCommands
    {
        private readonly IRestaurantMasterCommandRepository _commandRepository;
        private readonly IRestaurantMasterQueryRepository _queryRepository;

        public RestaurantMasterCommands(IRestaurantMasterCommandRepository commandRepository, IRestaurantMasterQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        /// <summary>
        /// Deletes a RestaurantMaster entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the RestaurantMaster to delete.</param>
        /// <returns>JSON response indicating the status of the delete operation.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await _commandRepository.Delete(id);
        }

        /// <summary>
        /// Inserts a new RestaurantMaster entity.
        /// </summary>
        /// <param name="obj">The RestaurantMaster object to insert.</param>
        /// <returns>JSON response indicating the status of the insert operation.</returns>
        public async Task<JsonResponse> Insert(RestaurantMaster obj)
        {
            var response = await _queryRepository.GetAll();

            IEnumerable<RestaurantMaster> restaurants = response.Data as IEnumerable<RestaurantMaster>; // Cast to the appropriate collection type

            if (restaurants != null)
            {
                // Check for email uniqueness
                if (restaurants.Any(r => r.Email == obj.Email))
                {
                    return new JsonResponse()
                    {
                        IsSuccess = false,
                        Message = "Email already exists.",
                        StatusCode = 409
                    };
                }

                // Check for restaurant code uniqueness
                if (restaurants.Any(r => r.RestaurantCode == obj.RestaurantCode))
                {
                    return new JsonResponse()
                    {
                        IsSuccess = false,
                        Message = "Restaurant code already exists.",
                        StatusCode = 409
                    };
                }

                // Check for restaurant name uniqueness
                if (restaurants.Any(r => r.Name == obj.Name))
                {
                    return new JsonResponse()
                    {
                        IsSuccess = false,
                        Message = "Restaurant name already exists.",
                        StatusCode = 404
                    };
                }
            }

            return await _commandRepository.Insert(obj);
        }

        /// <summary>
        /// Updates an existing RestaurantMaster entity.
        /// </summary>
        /// <param name="obj">The updated RestaurantMaster object.</param>
        /// <returns>JSON response indicating the status of the update operation.</returns>
        public async Task<JsonResponse> Update(RestaurantMaster obj)
        {
            var response = await _queryRepository.GetAll();

            IEnumerable<RestaurantMaster> restaurants = response.Data as IEnumerable<RestaurantMaster>; // Cast to the appropriate collection type

            if (restaurants != null)
            {
                // Check for email uniqueness
                if (restaurants.Any(r => r.Email == obj.Email && obj.Id != r.Id))
                {
                    return new JsonResponse()
                    {
                        IsSuccess = false,
                        Message = "Email already exists.",
                        StatusCode = 409
                    };
                }

                // Check for restaurant code uniqueness
                if (restaurants.Any(r => r.RestaurantCode == obj.RestaurantCode && obj.Id != r.Id))
                {
                    return new JsonResponse()
                    {
                        IsSuccess = false,
                        Message = "Restaurant code already exists.",
                        StatusCode = 409
                    };
                }

                // Check for restaurant name uniqueness
                if (restaurants.Any(r => r.Name == obj.Name && obj.Id != r.Id))
                {
                    return new JsonResponse()
                    {
                        IsSuccess = false,
                        Message = "Restaurant name already exists.",
                        StatusCode = 404
                    };
                }
            }

            return await _commandRepository.Update(obj);
        }
    }
}
