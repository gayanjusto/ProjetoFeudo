using System.Collections.Generic;

namespace ProjectFeudo.Domain.Itens
{
    public abstract class BaseItem
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public bool IsStackable { get; set; }

        public int MaxDuration { get; set; }

        public double Value { get; set; }

        public IEnumerable<int> ItemContextIds { get; set; }

        public int Rarity { get; set; }
    }
}


