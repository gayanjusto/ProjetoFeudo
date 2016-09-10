using System.Collections.Generic;
using ProjectFeudo.Domain.Itens;

namespace ProjectFeudo.Domain.Interfaces.DAO
{
    public interface IEquippableItemDAO : IItemDAO<EquippableItem>
    {
        EquippableItem GetItemByTypeAndBodyPart(string type, string bodyPart);
        EquippableItem GetItemById(string id);

    }
}

