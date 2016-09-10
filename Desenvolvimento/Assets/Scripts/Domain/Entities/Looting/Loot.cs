using System.Collections.Generic;
using UnityEngine;

namespace ProjectFeudo.Domain.Looting
{
    public class Loot : MonoBehaviour
    {
        public string LootId { get; set; }
        public IEnumerable<SpecificLootIdentifier> LootItemIdentifiers { get; set; }
    }
}


//JSON EXAMPLE:
/*

    CreatureLoot = {
    LootId: "loot99999999,
    LootItemIdentifiers: 
        [
            {
               	ItemId: "chm0001" //ChainmailChest
                ItemType: "Armor"
            },
            {
               	ItemId: "bow0001" //Short Bow
                ItemType: "Weapon"
            },
             {
               	ItemId: "dag0001" //Dagger
                ItemType: "Weapon"
            },
        ]
    }

*/
