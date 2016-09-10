using ProjectFeudo.Domain.Itens;
using UnityEngine;

namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface IInventoryManager
    {
        bool InsertItemIntoInventory(BaseItem item);
        void SetSlotToFreeSlotList(Transform slot);
        bool HasFreeSlot();
        Transform GetFreeSlot();
    }
}


