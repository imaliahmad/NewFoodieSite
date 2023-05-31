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
    /// <summary>
    /// Repository for querying restaurant master records.
    /// </summary>
    public class RestaurantMasterQueryRepository : IRestaurantMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantMasterQueryRepository"/> class.
        /// </summary>
        /// <param name="_context">The EF Core database context.</param>
        public RestaurantMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Retrieves all restaurant master records.
        /// </summary>
        /// <returns>A <see cref="JsonResponse"/> containing the restaurant master records.</returns>
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblRestaurantMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        /// <summary>
        /// Retrieves a restaurant master record by ID.
        /// </summary>
        /// <param name="id">The ID of the restaurant master record.</param>
        /// <returns>A <see cref="JsonResponse"/> containing the restaurant master record with the specified ID.</returns>
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblRestaurantMaster.Where(x => x.Id == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
