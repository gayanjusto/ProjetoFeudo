using System.Collections.Generic;
using UnityEngine;

namespace ProjectFeudo.Domain.Interfaces.DAO
{
    public interface IItemLootOptionPrefabDAO
    {
        IEnumerable<GameObject> GetOptionsByAmount(int itensAmount);
    }
}
  
