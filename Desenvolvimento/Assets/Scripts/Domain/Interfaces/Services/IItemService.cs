using ProjectFeudo.Domain.Itens;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Interfaces.Services
{
    public interface IItemService
    {
        IEnumerable<BaseItem> GetItemsFromCategories(IEnumerable<string> itemTypes);
    }
}
