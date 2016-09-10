using UnityEngine;

namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface ILootPanelManager : IBasePanel
    {
        void RemoveItemOption(GameObject optionGameObject);
        void InstantiateLootItems(string lootId);
    }
}


