using FoodieSite.CQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieSite.CQRS.Commands.interfaces
{
    public interface IItemMasterCommands
    {
        Task<JsonResponse> Insert(ItemMaster obj);
        Task<JsonResponse> Update(ItemMaster obj);
        Task<JsonResponse> Delete(Guid id);
    }
}
