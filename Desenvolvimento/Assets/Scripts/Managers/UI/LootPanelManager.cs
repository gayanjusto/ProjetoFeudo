using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Domain.Itens;
using ProjectFeudo.Services;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace ProjectFeudo.Managers
{
    public class LootPanelManager : BaseManager, ILootPanelManager
    {
        private Vector2 originalSize;
        private Scrollbar scrollBar;
        private float alteredHeight;
        private const float ITEM_OPTION_HEIGHT = 110;

        private ILootService lootService;

        void Start() {
            originalSize = this.GetComponent<RectTransform>().sizeDelta;
            lootService = lootService ?? new LootService();
            scrollBar = this.transform.parent.Find("Scrollbar").GetComponent<Scrollbar>();
            HidePanel();
        }


        public void RemoveItemOption(GameObject optionGameObject) {
            alteredHeight -= ITEM_OPTION_HEIGHT;
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(originalSize.x, alteredHeight);
            SetScrollBarToTop();
            Destroy(optionGameObject);
        }

        public void InstantiateLootItems(string lootId) {

            IDictionary<BaseItem, GameObject> itemOptionDictionary = lootService.InstantiateLootItems(lootId);

            float heightToIncrease = 0;
            foreach (var item in itemOptionDictionary) {
                GameObject instantiatedItem = Instantiate(item.Value);
                //option.transform.FindChild("LootItemImage").GetComponent<Image>();
                instantiatedItem.transform.FindChild("LootItemTitle").GetComponent<Text>().text = item.Key.Name;
                instantiatedItem.transform.FindChild("LootItemDescription").GetComponent<Text>().text = item.Key.Description;
                //instantiatedItem.transform.FindChild("LootItemAttributes").GetComponent<Text>().text = GetItemAttributes(item);
                instantiatedItem.transform.SetParent(this.transform, false);
                instantiatedItem.GetComponent<ILootItemManager>().InsertItemIntoLootSlot(item.Key);

                heightToIncrease += ITEM_OPTION_HEIGHT;
            }

            SetNewPanelHeight(heightToIncrease);
        }

        private void SetNewPanelHeight(float newHeight) {
            alteredHeight = newHeight;
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(originalSize.x, newHeight);
            SetScrollBarToTop();
        }

        private void SetScrollBarToTop() {
            this.scrollBar.value = 1;
        }
        public void ShowPanel() {
            CanvasGroup lootPanelCanvasGroup = this.transform.parent.GetComponent<CanvasGroup>();
            lootPanelCanvasGroup.alpha = 1;
            lootPanelCanvasGroup.interactable = true;
            lootPanelCanvasGroup.blocksRaycasts = true;
        }

        public void HidePanel() {
            CanvasGroup lootPanelCanvasGroup = this.transform.parent.GetComponent<CanvasGroup>();
            lootPanelCanvasGroup.alpha = 0;
            lootPanelCanvasGroup.interactable = false;
            lootPanelCanvasGroup.blocksRaycasts = false;
        }

       
    }
}

