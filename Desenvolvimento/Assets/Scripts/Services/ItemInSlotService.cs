using UnityEngine;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.DAO.Prefabs;

namespace ProjectFeudo.Services
{
    public class ItemInSlotService : IItemInSlotService
    {
        private readonly IItemInSlotPrefabDAO itemInSlotPrefabDAO;

        public ItemInSlotService() {
            itemInSlotPrefabDAO = new ItemInSlotPrefabDAO();
        }

        public GameObject GetItemInSlotPrefab() {
            return itemInSlotPrefabDAO.GetItemInSlotPrefab();
        }


    }
}

