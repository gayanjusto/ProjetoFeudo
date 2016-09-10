using UnityEngine;

namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface IAnimationManager
    {
        Animator GetAnimatorController();
        void SetAnimatorController(Animator animator);
        void SetAnimatorBoolTrue(string parameter);
        void SetAnimatorBoolFalse(string parameter);
        bool GetAnimatorBoolValue(string paramenter);
    }
}


