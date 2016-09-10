using Assets.Scripts.Domain.Entities.Looting;
using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Services;
using UnityEngine;

namespace ProjectFeudo.Managers
{
    public class InteractionManager : BaseManager, IInteractionManager
    {
        private GameObject objectInteracted;
        public Camera cameraUI;

        IBasePanel currentMenuInteraction;
        IInventoryUIManager inventoryUIManager;
        ILootService lootService;

        public bool mainMenuOpen;
        public bool inventoryMenuOpen;
        public bool characterSheetOpen;

        void Start() {
            inventoryUIManager = base.GetRootGameObject().transform.FindChild("InventoryUI").GetComponent<IInventoryUIManager>();
            lootService = lootService ?? new LootService();
            mainMenuOpen = false;
            inventoryMenuOpen = false;
            characterSheetOpen = false;
        }

        public void KeepObjectInMemory(GameObject objectInteracted) {
            this.objectInteracted = objectInteracted;
        }

        public void RemoveObjectInMemory(GameObject objectInteracted) {
            if (this.objectInteracted == objectInteracted)
                this.objectInteracted = null;
        }

        public void CloseCurrentMenu() {
            if (currentMenuInteraction != null)
                currentMenuInteraction.HidePanel();
        }

        public void OpenCloseInventoryMenu() {
            inventoryMenuOpen = !inventoryMenuOpen;

            if (inventoryMenuOpen) {
                EnableCameraUI();
                inventoryUIManager.ShowInventoryMenu();
            } else {
                DisableAllMenus();
                DisableCameraUI();
            }

            mainMenuOpen = false;
            characterSheetOpen = false;
        }

        public void OpenCloseCharacterSheetMenu() {
            characterSheetOpen = !characterSheetOpen;

            mainMenuOpen = false;
            inventoryMenuOpen = false;
        }

        public void OpenLootMenu() {
            inventoryUIManager.ShowLootMenu();
            EnableCameraUI();
        }

        public void FilterInteractionByTag() {

            if (objectInteracted == null) { return; }

            if (objectInteracted.tag == TagsEnum.InteractableLoot) {
                Debug.Log("Interactable loot");
                OpenLootMenu();

                if (!inventoryMenuOpen)
                    OpenCloseInventoryMenu();

                currentMenuInteraction = inventoryUIManager.GetMenu("LootScrollView/Loot Panel");
                return;
            }

            if (objectInteracted.tag == TagsEnum.InteractableNPC) {
                Debug.Log("Interactable NPC");
                return;
            }

            if (objectInteracted.tag == TagsEnum.InteractableObject) {
                Debug.Log("Interactable Object");
                return;
            }

            if (objectInteracted.tag == TagsEnum.RandomLoot) {
                LootIdentifierItem lootItensData = objectInteracted.GetComponent<LootIdentifierItem>();
                lootService.GetRandomLootByContextAndRarity(lootItensData.contextIds, lootItensData.itensMaxRarity);
                return;
            }
        }

        public void EnableCameraUI() {
            this.cameraUI.enabled = true;
        }

        public void DisableCameraUI() {
            this.cameraUI.enabled = false;
        }

        public void DisableAllMenus() {
            inventoryUIManager.DisableAllMenus();
        }
    }

}