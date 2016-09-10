using ProjectFeudo.Domain.Enums;
using System.Collections.Generic;

namespace ProjectFeudo.Domain.Itens
{
    public class EquippableItem : BaseItem
    {

        public EquippableItem() { }

        public string ParentPartId { get; set; }

        public int? Damage { get; set; }

        public string ItemMaterial { get; set; }

        public string ItemBodyPart { get; set; }

        public string ItemResourcesPath { get; set; }

        public List<EquippableItem> ChildPartList { get; set; }
    }
}


