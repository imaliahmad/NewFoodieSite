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
    public class OrderDetailsCommands : IOrderDetailsCommands
    {
        private readonly IOrderDetailsCommandRepository repository;
        public OrderDetailsCommands(IOrderDetailsCommandRepository _repository)
        {
            repository = _repository;
        }
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        public async Task<JsonResponse> Insert(OrderDetails obj)
        {
            return await repository.Insert(obj);
        }

        public async Task<JsonResponse> Update(OrderDetails obj)
        {
            return await repository.Update(obj);
        }
    }
}
