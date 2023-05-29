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

    public class CategoryMasterCommands : ICategoryMasterCommands
    {
        private readonly ICategoryMasterCommandRepository repository;
        public CategoryMasterCommands(ICategoryMasterCommandRepository _repository)
        {
            repository = _repository;
        }
        public async Task<JsonResponse> Delete(Guid id)
        {
            return await repository.Delete(id);
        }

        public async Task<JsonResponse> Insert(CategoryMaster obj)
        {
            return await repository.Insert(obj);
        }

        public async Task<JsonResponse> Update(CategoryMaster obj)
        {
            return await repository.Update(obj);
        }
    }
}
