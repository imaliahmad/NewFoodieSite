using FoodieSite.CQRS.Commands.interfaces;
using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Commands
{
    /// <summary>
    /// Implementation of commands for managing StoreMaster entities.
    /// </summary>
    public class StoreMasterCommands : IStoreMasterCommands
    {
        private readonly IStoreMasterCommandRepository _storeCommandRepository;
        private readonly IStoreMasterQueryRepository _storeQueryRepository;
        private readonly IRestaurantMasterQueryRepository _restaurantQueryRepository;

        /// <summary>
        /// Initializes a new instance of the StoreMasterCommands class.
        /// </summary>
        /// <param name="storeCommandRepository">The repository for StoreMaster commands.</param>
        /// <param name="storeQueryRepository">The repository for StoreMaster queries.</param>
        /// <param name="restaurantQueryRepository">The repository for RestaurantMaster queries.</param>
        public StoreMasterCommands(IStoreMasterCommandRepository storeCommandRepository,
            IStoreMasterQueryRepository storeQueryRepository,
            IRestaurantMasterQueryRepository restaurantQueryRepository)
        {
            _storeCommandRepository = storeCommandRepository;
            _storeQueryRepository = storeQueryRepository;
            _restaurantQueryRepository = restaurantQueryRepository;
        }

        /// <summary>
        /// Deletes a StoreMaster entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the StoreMaster entity to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await _storeCommandRepository.Delete(id);
        }

        /// <summary>
        /// Inserts a new StoreMaster entity.
        /// </summary>
        /// <param name="obj">The StoreMaster entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Insert(StoreMaster obj)
        {
            var isValid = await IsValid(obj);
            if (isValid.IsSuccess)
                return await _storeCommandRepository.Insert(obj);
            return isValid;
        }

        /// <summary>
        /// Updates an existing StoreMaster entity.
        /// </summary>
        /// <param name="obj">The StoreMaster entity to update.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Update(StoreMaster obj)
        {
            var isValid = await IsValid(obj);
            if (isValid.IsSuccess)
                return await _storeCommandRepository.Update(obj);
            return isValid;
        }

        /// <summary>
        /// Checks if the provided StoreMaster entity is valid.
        /// </summary>
        /// <param name="obj">The StoreMaster entity to validate.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> IsValid(StoreMaster obj)
        {
            // Retrieve all existing stores
            var storesResponse = await _storeQueryRepository.GetAll();
            IEnumerable<StoreMaster> stores = storesResponse.Data as IEnumerable<StoreMaster>;

            if (stores != null)
            {
                // Check for name uniqueness
                foreach (var store in stores)
                {
                    if (store.Name == obj.Name && store.Id != obj.Id)
                    {
                        return new JsonResponse()
                        {
                            IsSuccess = false,
                            Message = "Name already exists.",
                            StatusCode = 409
                        };
                    }
                }
            }

            // Retrieve all existing restaurants
            var restaurantsResponse = await _restaurantQueryRepository.GetAll();
            IEnumerable<RestaurantMaster> restaurants = restaurantsResponse.Data as IEnumerable<RestaurantMaster>;

            if (restaurants != null)
            {
                // Check for FK RestaurantId existence
                foreach (var restaurant in restaurants)
                {
                    if (restaurant.Id == obj.RestaurantId)
                    {
                        return new JsonResponse()
                        {
                            IsSuccess = true,
                            StatusCode = 200
                        };
                    }
                }
            }

            // If the object is valid, return a success response
            return new JsonResponse()
            {
                IsSuccess = false,
                Message = "Restaurant ID is invalid.",
                StatusCode = 409
            };

        }

    }
}
