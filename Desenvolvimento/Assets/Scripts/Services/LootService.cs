using ProjectFeudo.DAO;
using ProjectFeudo.DAO.Prefabs;
using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Domain.Itens;
using ProjectFeudo.Domain.Looting;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Assets.Scripts.Domain.Interfaces.Services;

namespace ProjectFeudo.Services
{
    public class LootService : ILootService
    {
        private ILootDAO lootDAO;
        private ICommonItemDAO commonItemDAO;
        private IEquippableItemDAO equippableItemDAO;
        private IItemLootOptionPrefabDAO itemLootOptionPrefabDAO;
        private IItemService itemService;

        public LootService() {
            lootDAO = lootDAO ?? new LootDAO();
            commonItemDAO = commonItemDAO ?? new CommonItemDAO();
            equippableItemDAO = equippableItemDAO ?? new EquippableItemDAO();
            itemService = itemService ?? new ItemService();
            itemLootOptionPrefabDAO = itemLootOptionPrefabDAO ?? new ItemLootOptionPrefabDAO();
        }

        public IDictionary<BaseItem, GameObject> InstantiateLootItems(string lootId) {

            Loot loot = lootDAO.GetLootById(lootId);

            IEnumerable<string> itemTypes = loot.LootItemIdentifiers.Select(x => x.ItemType).Distinct();

            IList<BaseItem> itens = itemService.GetItemsFromCategories(itemTypes).ToList();

            return PopulateItemOptionDictionary(itens); ;
        }

        public IDictionary<BaseItem, GameObject> GetRandomLootByContextAndRarity(int[] contextIds, int itensMaxRarity) {
            System.Random rnd = new System.Random();

            int MIN_AMOUNT = 3;
            int MAX_AMOUNT  = 10;

            int amountItens = rnd.Next(MIN_AMOUNT, MAX_AMOUNT);

            int amountEquippableItens = amountItens / 3;

            List<BaseItem> itemList = new List<BaseItem>();

            IEnumerable<CommonItem> commonItemArray = commonItemDAO.GetItensByContextAndRarity(contextIds, itensMaxRarity)
                .Take(amountItens - amountEquippableItens);

            foreach (var item in commonItemArray) {
                itemList.Add(item);
            }

            IEnumerable<EquippableItem> equipItemArray = equippableItemDAO.GetItensByContextAndRarity(contextIds, itensMaxRarity)
                .Take(amountEquippableItens);

            foreach (var item in equipItemArray) {
                itemList.Add(item);
            }

            return PopulateItemOptionDictionary(itemList);
        }

        IDictionary<BaseItem, GameObject> PopulateItemOptionDictionary(IList<BaseItem> itens) {
            IList<GameObject> options = itemLootOptionPrefabDAO.GetOptionsByAmount(itens.Count()).ToList();

            IDictionary<BaseItem, GameObject> itemOptionDictionary = new Dictionary<BaseItem, GameObject>();

            for (int i = 0; i < itens.Count(); i++) {
                itemOptionDictionary.Add(new KeyValuePair<BaseItem, GameObject>(itens[i], options[i]));
            }

            return itemOptionDictionary;
        }
    }
}


