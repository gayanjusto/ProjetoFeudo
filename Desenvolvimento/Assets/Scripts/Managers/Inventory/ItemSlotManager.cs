using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Interfaces.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectFeudo.Managers
{
    public class ItemSlotManager : BaseItemManager, IItemSlotManager, IDropHandler
    {

        public void OnDrop(PointerEventData eventData) {
            ItemInSlotManager itemInSlotManager = eventData.pointerDrag.GetComponent<ItemInSlotManager>();
            itemInSlotManager.SetHasDroppedOnValidSlot(true);

            if (this.transform.tag == TagsEnum.FullItemSlot) {
                base.SwapSlots(eventData, itemInSlotManager);
                return;
            }

            itemInSlotManager.GetParentBeforeDrag().tag = TagsEnum.EmptyItemSlot;

            itemInSlotManager.transform.SetParent(this.transform);
            itemInSlotManager.transform.localPosition = new Vector2(0, 0); // new Vector2(this.transform.localPosition.x, this.transform.localPosition.y - 40);

            this.transform.tag = TagsEnum.FullItemSlot;
        }

    }

}
