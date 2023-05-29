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
    public class PaymentMasterQueryRepository : IPaymentMasterQueryRepository
    {
        private readonly EFCoreDbContext context;

        public PaymentMasterQueryRepository(EFCoreDbContext _context)
        {
            context = _context;
        }

        // Retrieves all payment master records
        public async Task<JsonResponse> GetAll()
        {
            var list = await context.tblPaymentMaster.Where(x => x.IsActive == true).ToListAsync();
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = list };
        }

        // Retrieves payment master records by order ID
        public async Task<JsonResponse> GetByOrderId(Guid id)
        {
            var obj = await context.tblPaymentMaster.Where(x => x.OrderId == id && x.IsActive == true).ToListAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }
            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }

        // Retrieves a payment master record by ID
        public async Task<JsonResponse> GetById(Guid id)
        {
            var obj = await context.tblPaymentMaster.Where(x => x.Id == id && x.IsActive == true).FirstOrDefaultAsync();
            if (obj == null)
            {
                return new JsonResponse() { IsSuccess = false, StatusCode = 404, Message = "Record Not Found." };
            }

            return new JsonResponse() { IsSuccess = true, StatusCode = 200, Data = obj };
        }
    }
}
