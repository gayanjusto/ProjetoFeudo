using UnityEngine;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.DAO;
using ProjectFeudo.Managers;
using ProjectFeudo.Domain.Paths;
using ProjectFeudo.Domain.Itens;
using ProjectFeudo.Domain.Enums;

namespace ProjectFeudo.Services
{
    public class AnimationService : IAnimationService
    {

        private IAnimationClipDAO animationClipRepository;
        private AnimatorService animatorService;

        public AnimationService() {
            animationClipRepository = animationClipRepository ?? new AnimationClipDAO();
            animatorService = animatorService ?? new AnimatorService();
        }
        public Animator ChangeAnimationClipsByBodyPart(AnimationManager animationManager, EquippableItem item) {

            AnimationClip[] clipsByBodyPart = animationClipRepository.GetItemAllDirectionByBodyPartClips(
                 AnimationRaceResourcesPath.humanoid, item);

            Animator animatorController = animationManager.GetAnimatorController();
            animatorController.runtimeAnimatorController = animatorService.OverrideAnimatorController(
                animatorController.runtimeAnimatorController,
             clipsByBodyPart);

            return animatorController;
        }

        public void OverrideObjectAnimator(GameObject rootGameObject, EquippableItem item) {
            AnimationManager animationManager = rootGameObject.GetComponent<AnimationManager>();

            animationManager.SetAnimatorController(ChangeAnimationClipsByBodyPart(animationManager, item));
        }
    }

}