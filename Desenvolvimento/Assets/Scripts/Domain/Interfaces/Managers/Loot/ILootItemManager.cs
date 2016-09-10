using ProjectFeudo.Domain.Itens;

namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface ILootItemManager
    {
        void InsertItemIntoLootSlot(BaseItem item);
    }

}
