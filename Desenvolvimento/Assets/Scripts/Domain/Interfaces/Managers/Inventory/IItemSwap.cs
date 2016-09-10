using ProjectFeudo.Managers;
using UnityEngine.EventSystems;

namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface IItemSwap
    {
        void SwapSlots(PointerEventData eventData, ItemInSlotManager movingItemManager);
    }
}


