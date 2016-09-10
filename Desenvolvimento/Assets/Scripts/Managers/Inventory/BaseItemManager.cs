using UnityEngine;
using UnityEngine.EventSystems;
using ProjectFeudo.Domain.Interfaces.Managers;

namespace ProjectFeudo.Managers
{
    public class BaseItemManager : BaseManager, IItemSwap
    {
        public void SwapSlots(PointerEventData eventData, ItemInSlotManager movingItemManager) {
            Transform movingItemParent = movingItemManager.GetParentBeforeDrag();
            Vector3 movingSlotOriginalPosition = movingItemManager.GetOriginalPosition();

            Transform droppedSlotItem = this.transform.GetChild(0);
            Vector3 droppedSlotLocalPosition = droppedSlotItem.transform.localPosition;

            droppedSlotItem.SetParent(movingItemParent);
            droppedSlotItem.localPosition = new Vector2(movingSlotOriginalPosition.x, movingSlotOriginalPosition.y);

            eventData.pointerDrag.transform.SetParent(this.transform);
            eventData.pointerDrag.transform.localPosition = droppedSlotLocalPosition;
        }

        public IItemInSlotManager CurrentItemInSlotManager {
            get {
                return transform.Find("ItemInSlot").GetComponent<IItemInSlotManager>();
            }
        }
    }
}

