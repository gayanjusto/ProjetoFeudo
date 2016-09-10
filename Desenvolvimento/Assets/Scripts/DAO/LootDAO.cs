using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.Domain.Looting;
using System.Linq;

namespace ProjectFeudo.DAO
{
    public class LootDAO : BaseDAO<Loot>, ILootDAO
    {

        public LootDAO() {
            base.AssetsFolder = "/Loot/";
        }

        public Loot GetLootById(string lootId) {
            var itens = base.GetAllFromSpecificFile("loot", ".json");

            var item = itens.First(x => x.LootId == lootId);
            itens = null;

            return item;
        }

    }
}


