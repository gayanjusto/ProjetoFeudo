using ProjectFeudo.Domain.Looting;

namespace ProjectFeudo.Domain.Interfaces.DAO
{
    public interface ILootDAO
    {
        Loot GetLootById(string id);
    }
}

