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
    public class OrderStatusCommands : IOrderStatusCommands
    {
        private readonly IOrderStatusCommandRepository repository;
        public OrderStatusCommands(IOrderStatusCommandRepository _repository)
        {
            repository = _repository;
        }
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        public async Task<JsonResponse> Insert(OrderStatus obj)
        {
            return await repository.Insert(obj);
        }

        public async Task<JsonResponse> Update(OrderStatus obj)
        {
            return await repository.Update(obj);
        }
    }
}
