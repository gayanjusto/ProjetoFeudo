using ProjectFeudo.Domain.Itens;

namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface IItemInSlotManager
    {
        string GetItemInInventoryId();

        void SetItemInInventoryId(string id);

        BaseItem GetCurrentItemInSlot();

        void SetCurrentItemInSlot(BaseItem item);
    }

}

