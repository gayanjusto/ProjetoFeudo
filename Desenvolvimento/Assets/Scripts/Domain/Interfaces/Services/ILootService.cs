using ProjectFeudo.Domain.Itens;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectFeudo.Domain.Interfaces.Services
{
    public interface ILootService
    {
        IDictionary<BaseItem, GameObject> InstantiateLootItems(string lootId);
        IDictionary<BaseItem, GameObject> GetRandomLootByContextAndRarity(int[] contextIds, int itensMaxRarity);

    }
}


