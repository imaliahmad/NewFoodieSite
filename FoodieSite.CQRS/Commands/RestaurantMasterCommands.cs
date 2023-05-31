using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Models;
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

        /// <summary>
        /// Initializes a new instance of the RestaurantMasterCommands class.
        /// </summary>
        /// <param name="commandRepository">The repository for executing commands on RestaurantMaster entities.</param>
        /// <param name="queryRepository">The repository for querying RestaurantMaster entities.</param>
        public RestaurantMasterCommands(IRestaurantMasterCommandRepository commandRepository, 
            IRestaurantMasterQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        /// <summary>
        /// Deletes a RestaurantMaster entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the RestaurantMaster to delete.</param>
        /// <returns>A JSON response indicating the status of the delete operation.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await _commandRepository.Delete(id);
        }

        /// <summary>
        /// Inserts a new RestaurantMaster entity.
        /// </summary>
        /// <param name="obj">The RestaurantMaster object to insert.</param>
        /// <returns>A JSON response indicating the status of the insert operation.</returns>
        public async Task<JsonResponse> Insert(RestaurantMaster obj)
        {
            var isValid = await IsValid(obj);

            // If the object is valid, perform the insert operation
            if (isValid.IsSuccess)
                return await _commandRepository.Insert(obj);

            return isValid;
        }

        /// <summary>
        /// Updates an existing RestaurantMaster entity.
        /// </summary>
        /// <param name="obj">The updated RestaurantMaster object.</param>
        /// <returns>A JSON response indicating the status of the update operation.</returns>
        public async Task<JsonResponse> Update(RestaurantMaster obj)
        {
            var isValid = await IsValid(obj);

            // If the object is valid, perform the update operation
            if (isValid.IsSuccess)
                return await _commandRepository.Update(obj);

            return isValid;
        }

        /// <summary>
        /// Validates if a RestaurantMaster object is valid.
        /// </summary>
        /// <param name="obj">The RestaurantMaster object to validate.</param>
        /// <returns>A JSON response indicating the validation status.</returns>
        public async Task<JsonResponse> IsValid(RestaurantMaster obj)
        {
            // Retrieve all existing restaurants
            var response = await _queryRepository.GetAll();
            IEnumerable<RestaurantMaster> restaurants = response.Data as IEnumerable<RestaurantMaster>;

            if (restaurants != null)
            {
                // Check for restaurant name uniqueness
                foreach (var restaurant in restaurants)
                {
                    if (restaurant.Name == obj.Name && restaurant.Id != obj.Id)
                    {
                        return new JsonResponse()
                        {
                            IsSuccess = false,
                            Message = "Restaurant name already exists.",
                            StatusCode = 409
                        };
                    }
                }

                // Check for restaurant code uniqueness
                foreach (var restaurant in restaurants)
                {
                    if (restaurant.RestaurantCode == obj.RestaurantCode && restaurant.Id != obj.Id)
                    {
                        return new JsonResponse()
                        {
                            IsSuccess = false,
                            Message = "Restaurant code already exists.",
                            StatusCode = 409
                        };
                    }
                }

                // Check for email uniqueness
                foreach (var restaurant in restaurants)
                {
                    if (restaurant.Email == obj.Email && restaurant.Id != obj.Id)
                    {
                        return new JsonResponse()
                        {
                            IsSuccess = false,
                            Message = "Restaurant email already exists.",
                            StatusCode = 409
                        };
                    }
                }

            }

            // If the object is valid, return a success response
            return new JsonResponse()
            {
                IsSuccess = true,
                StatusCode = 200
            };
        }

    }
}
