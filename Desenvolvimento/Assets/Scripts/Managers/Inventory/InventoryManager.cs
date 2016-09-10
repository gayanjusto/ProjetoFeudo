using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Domain.Itens;
using ProjectFeudo.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace ProjectFeudo.Managers
{
    public class InventoryManager : BaseManager, IInventoryManager
    {

        public GameObject itensPanel;
        public List<Transform> FreeItemSlots;
        private List<Transform> OccupiedItemSlots;
        private IInventoryService inventoryService;
        private IItemInSlotService itemInSlotService;


        void Start() {
            FreeItemSlots = new List<Transform>();
            OccupiedItemSlots = new List<Transform>();

            inventoryService = inventoryService ?? new InventoryService();
            itemInSlotService = itemInSlotService ?? new ItemInSlotService();

            itensPanel = GameObject.Find("Itens Panel");
            PopullateFreeItemSlots();
        }


        public bool InsertItemIntoInventory(BaseItem item) {

            Transform freeSlot = GetFreeSlot();

            if (freeSlot != null) {
                freeSlot.tag = TagsEnum.FullItemSlot;

                GameObject itemInSlotPrefab = Instantiate(itemInSlotService.GetItemInSlotPrefab());

                itemInSlotPrefab.GetComponent<ItemInSlotManager>()
                    .SetCurrentItemInSlot(item);

                itemInSlotPrefab.transform.SetParent(freeSlot, false);

                FreeItemSlots.Remove(freeSlot);
                OccupiedItemSlots.Add(freeSlot);

                freeSlot.GetComponent<Image>().color = Color.green;

                return true;
            }

            return false;
        }

        private void PopullateFreeItemSlots() {
            foreach (Transform child in itensPanel.transform) {
                FreeItemSlots.Add(child);
            }
        }

        public Transform GetFreeSlot() {
            return FreeItemSlots.FirstOrDefault();
        }

        public bool HasFreeSlot() {
            return FreeItemSlots.Count > 0;
        }

        public void SetSlotToFreeSlotList(Transform slot) {
            if (OccupiedItemSlots.IndexOf(slot) != -1) {
                OccupiedItemSlots.Remove(slot);

                slot.tag = TagsEnum.EmptyItemSlot;
                FreeItemSlots.Add(slot);
            }
        }
    }
}
