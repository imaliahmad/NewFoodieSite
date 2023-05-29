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
    public class CustomerMasterQueryRepository : ICustomerMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        public CustomerMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        // Retrieves all customers
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblCustomerMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse { IsSuccess = true, StatusCode = 200, Data = list };
        }

        // Retrieves a customer by ID
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblCustomerMaster.Where(x => x.Id == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }
            return new JsonResponse { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
