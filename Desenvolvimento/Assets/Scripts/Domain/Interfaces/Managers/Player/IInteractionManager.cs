using UnityEngine;

namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface IInteractionManager
    {
        void KeepObjectInMemory(GameObject objectInteracted);
        void RemoveObjectInMemory(GameObject objectInteracted);
        void CloseCurrentMenu();
        void OpenCloseInventoryMenu();
        void OpenCloseCharacterSheetMenu();
        void FilterInteractionByTag();
        void EnableCameraUI();
        void DisableCameraUI();
    }
}


