using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Itens;
using ProjectFeudo.Managers;
using UnityEngine;

namespace ProjectFeudo.Domain.Interfaces.Services
{
    public interface IAnimationService
    {
        Animator ChangeAnimationClipsByBodyPart(AnimationManager animationManager, EquippableItem item);
        void OverrideObjectAnimator(GameObject rootGameObject, EquippableItem item);
    }

}

