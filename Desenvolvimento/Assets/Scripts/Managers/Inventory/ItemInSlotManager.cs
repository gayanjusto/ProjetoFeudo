using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Domain.Itens;
using UnityEngine;
using UnityEngine.EventSystems;


namespace ProjectFeudo.Managers
{
    public class ItemInSlotManager : BaseManager, IBeginDragHandler, IDragHandler, IEndDragHandler, IItemInSlotManager
    {

        public Transform inventoryPanel;
        private Transform parentBeforeDrag;
        private Vector3 originalPosition;
        public BaseItem currentItemInSlot;

        public string itemInInventoryId;
        private bool hasDroppedOnValidSlot;

        void Start() {
            inventoryPanel = this.transform.parent.parent.parent;
        }

        public void OnBeginDrag(PointerEventData eventData) {

            parentBeforeDrag = this.transform.parent;

            this.hasDroppedOnValidSlot = false;

            originalPosition = this.transform.localPosition;


            RectTransform parentRect = (RectTransform)inventoryPanel;
            Vector2 posInParent;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, eventData.position, eventData.pressEventCamera, out posInParent);

            this.transform.localPosition = parentRect.transform.localPosition;
        }

        public void OnDrag(PointerEventData eventData) {

            this.GetComponent<CanvasGroup>().blocksRaycasts = false;

            this.transform.SetParent(inventoryPanel);

            RectTransform parentRect = (RectTransform)this.transform.parent;


            Vector2 posInParent;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, eventData.position, eventData.pressEventCamera, out posInParent);


            this.transform.localPosition = new Vector2(posInParent.x, posInParent.y);
        }

        public void OnEndDrag(PointerEventData eventData) {
            if (!hasDroppedOnValidSlot)
                ReturnToOriginalPosition();

            eventData.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;

            CheckEquipmentSlotEmpty();
        }

        void CheckEquipmentSlotEmpty() {
            if (this.parentBeforeDrag.transform.tag == TagsEnum.EmptyItemSlot) {
                IEquipmentSlotManager equipmentComponent = this.parentBeforeDrag.GetComponent<IEquipmentSlotManager>();
                if (equipmentComponent != null) {
                    equipmentComponent.RemoveEquipmentToBare();
                }
            }
        }

        public void ReturnToOriginalPosition() {
            this.transform.SetParent(parentBeforeDrag);
            this.transform.localPosition = originalPosition;
        }

        public BaseItem GetCurrentItemInSlot() {
            return this.currentItemInSlot;
        }

        public void SetCurrentItemInSlot(BaseItem item) {
            this.currentItemInSlot = item;
        }

        public Transform GetParentBeforeDrag() {
            return this.parentBeforeDrag;
        }
        public string GetItemInInventoryId() {
            return this.itemInInventoryId;
        }

        public void SetItemInInventoryId(string id) {
            itemInInventoryId = id;
        }

        public void SetHasDroppedOnValidSlot(bool isValid) {
            this.hasDroppedOnValidSlot = isValid;
        }

        public Vector3 GetOriginalPosition() {
            return this.originalPosition;
        }

    }
}
