using UnityEngine;
using ProjectFeudo.Domain.Interfaces.Managers;
using UnityEngine.UI;
using System.Collections;
using System;

namespace ProjectFeudo.Managers
{
    public class InventoryUIManager : MonoBehaviour, IInventoryUIManager
    {

        private ILootPanelManager lootPanelManager;
        private IInventoryPanelManager inventoryPanelManager;
        private Transform messageElement;

        void Start() {
            lootPanelManager = this.transform.GetChild(0).FindChild("LootScrollView/Loot Panel").GetComponent<ILootPanelManager>();
            inventoryPanelManager = this.transform.GetChild(0).FindChild("Inventory Panel").GetComponent<IInventoryPanelManager>();
            messageElement = this.transform.GetChild(0).FindChild("Message");
        }

        public void ShowMessage(string message) {
            messageElement.GetComponent<Text>().text = message;
            StartCoroutine(HideMessage());
        }

        private IEnumerator HideMessage() {
            yield return new WaitForSeconds(5);
            messageElement.GetComponent<Text>().text = string.Empty;
        }

        public void DisableAllMenus() {
            lootPanelManager.HidePanel();
            inventoryPanelManager.HidePanel();
        }

        public void ShowLootMenu() {
            lootPanelManager.ShowPanel();
        }

        public void HideLootMenu() {
            lootPanelManager.HidePanel();
        }

        public void ShowInventoryMenu() {
            inventoryPanelManager.ShowPanel();
        }

        public void HideInventoryMenu() {
            inventoryPanelManager.HidePanel();
        }

        public IBasePanel GetMenu(string menuPath) {
            return this.transform.GetChild(0).FindChild(menuPath).GetComponent<IBasePanel>();
        }
    }

}