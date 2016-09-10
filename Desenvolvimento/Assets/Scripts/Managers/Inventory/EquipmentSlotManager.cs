using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Domain.Itens;
using ProjectFeudo.Services;
using UnityEngine;
using UnityEngine.EventSystems;


namespace ProjectFeudo.Managers
{

    public class EquipmentSlotManager : BaseItemManager, IEquipmentSlotManager, IDropHandler
    {
        public string slotBodyPart;

        GameObject playerObject;
        AnimationManager playerAnimationManager;
        IInventoryManager inventoryManager;

        IInventoryService inventoryService;
        IAnimationService animationService;

        public IInventoryManager InventoryManager {
            get {
                return inventoryManager;
            }

            set {
                inventoryManager = value;
            }
        }

        void Start() {
            playerObject = transform.root.gameObject;
            playerAnimationManager = playerObject.GetComponent<AnimationManager>();
            InventoryManager = playerObject.GetComponent<InventoryManager>();

            inventoryService = new InventoryService();
            InventoryManager = InventoryManager ?? new InventoryManager();
            animationService = animationService ?? new AnimationService();
        }

        public void OnDrop(PointerEventData eventData) {
            ItemInSlotManager itemInSlotManager = eventData.pointerDrag.GetComponent<ItemInSlotManager>();
            EquippableItem itemInSlot = itemInSlotManager.GetCurrentItemInSlot() is EquippableItem ?
                (EquippableItem)itemInSlotManager.GetCurrentItemInSlot() : null;

            if (itemInSlot != null && itemInSlot.ItemBodyPart == slotBodyPart) {

                if (this.transform.tag == TagsEnum.FullItemSlot) {
                    base.SwapSlots(eventData, itemInSlotManager);
                    return;
                }

                animationService.OverrideObjectAnimator(base.GetRootGameObject(), itemInSlotManager.GetCurrentItemInSlot() as EquippableItem);

                transform.tag = TagsEnum.FullItemSlot;

                eventData.pointerDrag.transform.SetParent(this.transform);
                eventData.pointerDrag.transform.localPosition = new Vector2(0, 0);
                itemInSlotManager.SetHasDroppedOnValidSlot(true);

                InventoryManager.SetSlotToFreeSlotList(itemInSlotManager.GetParentBeforeDrag());
            } else {
                itemInSlotManager.ReturnToOriginalPosition();
            }
        }

        public void RemoveEquipmentToBare() {
            inventoryService.EquipBarePart(base.GetRootGameObject(), this.slotBodyPart);
        }

    }
}
