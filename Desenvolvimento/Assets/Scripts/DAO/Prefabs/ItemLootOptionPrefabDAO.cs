using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.Domain.Itens;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectFeudo.DAO.Prefabs
{
    public class ItemLootOptionPrefabDAO : IItemLootOptionPrefabDAO
    {
        public IEnumerable<GameObject> GetOptionsByAmount(int itensAmount) {

            List<GameObject> lootOptionList = new List<GameObject>();

            for (int i = 0; i < itensAmount; i++) {
                GameObject option = (GameObject)Resources.Load("Prefabs/Loot/ItemLootOption");
                lootOptionList.Add(option);
            }


            return lootOptionList;
        }

        private string GetItemAttributes(BaseItem item) {
            if (item is EquippableItem) {
                EquippableItem equipItem = item as EquippableItem;
                return string.Format("DEX: {0} AR: {1} VL: {2}", equipItem.Damage, "99", equipItem.Value);
            }

            return string.Format("VL: {0}", item.Value);
        }
    }
}
