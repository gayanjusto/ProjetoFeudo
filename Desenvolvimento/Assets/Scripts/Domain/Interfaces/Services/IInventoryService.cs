using ProjectFeudo.Domain.Itens;
using UnityEngine;

namespace ProjectFeudo.Domain.Interfaces.Services
{
    public interface IInventoryService
    {
        EquippableItem EquipItem(GameObject rootGameObject, string itemId);
        EquippableItem EquipBarePart(GameObject rootGameObject, string bodyPart);
    }
}


