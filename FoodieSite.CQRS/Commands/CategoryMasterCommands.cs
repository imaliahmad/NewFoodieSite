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
    /// Implementation of commands for managing CategoryMaster entities.
    /// </summary>
    public class CategoryMasterCommands : ICategoryMasterCommands
    {
        private readonly ICategoryMasterCommandRepository categoryCommandRepository;
        private readonly ICategoryMasterQueryRepository categoryQueryRepository;
        private readonly IStoreMasterQueryRepository storeQueryRepository;

        /// <summary>
        /// Initializes a new instance of the CategoryMasterCommands class.
        /// </summary>
        /// <param name="_categoryCommandRepository">The repository for CategoryMaster commands.</param>
        public CategoryMasterCommands(ICategoryMasterCommandRepository _categoryCommandRepository, 
            ICategoryMasterQueryRepository _categoryQueryRepository,
            IStoreMasterQueryRepository _storeQueryRepository)
        {
            categoryCommandRepository = _categoryCommandRepository;
            categoryQueryRepository = _categoryQueryRepository;
            storeQueryRepository = _storeQueryRepository;
        }

        /// <summary>
        /// Deletes a CategoryMaster entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the CategoryMaster entity to delete.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await categoryCommandRepository.Delete(id);
        }

        /// <summary>
        /// Inserts a new CategoryMaster entity.
        /// </summary>
        /// <param name="obj">The CategoryMaster entity to insert.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Insert(CategoryMaster obj)
        {
            var isValid = await IsValid(obj);
            if (isValid.IsSuccess)
                return await categoryCommandRepository.Insert(obj);
            return isValid;
        }

        /// <summary>
        /// Updates an existing CategoryMaster entity.
        /// </summary>
        /// <param name="obj">The CategoryMaster entity to update.</param>
        /// <returns>A task representing the asynchronous operation, returning the JSON response.</returns>
        public async Task<JsonResponse> Update(CategoryMaster obj)
        {
            var isValid = await IsValid(obj);
            if (isValid.IsSuccess)
                return await categoryCommandRepository.Update(obj);
            return isValid;
        }

        public async Task<JsonResponse> IsValid(CategoryMaster obj)
        {
            // Retrieve all existing categories
            var categoriesResponse = await categoryQueryRepository.GetAll();
            IEnumerable<CategoryMaster> categories = categoriesResponse.Data as IEnumerable<CategoryMaster>;

            if (categories != null)
            {
                // Check for Name uniqueness
                foreach (var category in categories)
                {
                    if (category.Name == obj.Name && category.StoreId == obj.StoreId && category.Id != obj.Id)
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

            // Retrieve all existing stores
            var storeResponse = await storeQueryRepository.GetAll();
            IEnumerable<StoreMaster> stores = storeResponse.Data as IEnumerable<StoreMaster>;

            if (stores != null)
            {
                // Check for FK StoreId uniqueness
                foreach (var store in stores)
                {
                    if (store.Id == obj.StoreId)
                    {
                        return new JsonResponse()
                        {
                            IsSuccess = true,
                            StatusCode = 200
                        };
                    }
                }
            }

            return new JsonResponse()
            {
                IsSuccess = false,
                Message = "Store id is invalid.",
                StatusCode = 409
            };

        }
    }
}
