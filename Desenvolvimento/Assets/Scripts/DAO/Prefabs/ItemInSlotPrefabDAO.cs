using ProjectFeudo.Domain.Interfaces.DAO;
using UnityEngine;

namespace ProjectFeudo.DAO.Prefabs
{
    public class ItemInSlotPrefabDAO : IItemInSlotPrefabDAO
    {
        public GameObject GetItemInSlotPrefab() {
            return (GameObject)Resources.Load("Prefabs/Inventory/ItemInSlot");
        }
    }
}
  
