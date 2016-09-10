using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Domain.Itens;
using UnityEngine.EventSystems;

namespace ProjectFeudo.Managers
{
    public class LootItemManager : BaseManager, ILootItemManager, IPointerClickHandler
    {
        ILootPanelManager lootPanelManager;
        IInventoryUIManager inventoryUIManager;
        IInventoryManager inventoryManager;
        BaseItem itemInLoot;

        void Start() {
            inventoryUIManager = GetRootGameObject().transform.Find("InventoryUI").GetComponent<IInventoryUIManager>();
            inventoryManager = GetRootGameObject().transform.GetComponent<IInventoryManager>();
            lootPanelManager = this.transform.parent.GetComponent<ILootPanelManager>();
        }

        public void OnPointerClick(PointerEventData eventData) {
            if (!inventoryManager.HasFreeSlot()) {
                inventoryUIManager.ShowMessage("Not enough space.");
                return;
            }

            inventoryManager.InsertItemIntoInventory(itemInLoot);
            lootPanelManager.RemoveItemOption(this.gameObject);
        }

        public void InsertItemIntoLootSlot(BaseItem item) {
            this.itemInLoot = item;
        }

    }
}

