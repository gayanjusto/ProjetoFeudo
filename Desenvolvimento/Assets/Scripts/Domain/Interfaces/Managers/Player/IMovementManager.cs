using UnityEngine;

namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface IMovementManager
    {
        void InsertKeyIntoInputList(KeyCode key);
        void RemoveKeyIntoInputList(KeyCode key);
        int GetHorizontalMovementValue();
        int GetVerticalMovementValue();
        bool AnyKeyPressed();
        void SetIsRunning(bool isRunning);
    }
}


