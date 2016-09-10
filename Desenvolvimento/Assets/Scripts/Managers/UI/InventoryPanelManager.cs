using System;
using ProjectFeudo.Domain.Interfaces.Managers;
using UnityEngine;

namespace ProjectFeudo.Managers
{
    public class InventoryPanelManager : MonoBehaviour, IInventoryPanelManager
    {
        public void HidePanel() {
            CanvasGroup lootPanelCanvasGroup = this.transform.GetComponent<CanvasGroup>();
            lootPanelCanvasGroup.alpha = 0;
            lootPanelCanvasGroup.interactable = false;
            lootPanelCanvasGroup.blocksRaycasts = false;
        }

        public void ShowPanel() {
            CanvasGroup lootPanelCanvasGroup = this.transform.GetComponent<CanvasGroup>();
            lootPanelCanvasGroup.alpha = 1;
            lootPanelCanvasGroup.interactable = true;
            lootPanelCanvasGroup.blocksRaycasts = true;
        }
    }
}
  
