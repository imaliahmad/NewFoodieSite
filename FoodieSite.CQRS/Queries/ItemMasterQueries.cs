using FoodieSite.CQRS.Models;
using FoodieSite.CQRS.Queries.interfaces;
using FoodieSite.CQRS.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Queries
{
    /// <summary>
    /// Represents a class that implements the queries for the ItemMaster entity.
    /// </summary>
    public class ItemMasterQueries : IItemMasterQueries
    {
        private readonly IItemMasterQueryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemMasterQueries"/> class.
        /// </summary>
        /// <param name="_repository">The repository for ItemMaster queries.</param>
        public ItemMasterQueries(IItemMasterQueryRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// Gets all the ItemMaster entities.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. The task result contains the JSON response.</returns>
        public async Task<JsonResponse> GetAll()
        {
            return await repository.GetAll();
        }

        /// <summary>
        /// Gets an ItemMaster entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the ItemMaster entity.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. The task result contains the JSON response.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            return await repository.GetById(id);
        }
    }
}
