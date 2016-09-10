namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface IInventoryUIManager
    {
        void ShowMessage(string message);
        void DisableAllMenus();
        void ShowLootMenu();
        void HideLootMenu();
        void ShowInventoryMenu();
        void HideInventoryMenu();
        IBasePanel GetMenu(string menuName);
    }
}


