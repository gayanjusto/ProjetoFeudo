using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Services;
using UnityEngine;


namespace ProjectFeudo.Managers
{
    public class AnimationManager : BaseManager, IAnimationManager
    {

        private IMovementManager movementManager;
        private AnimatorService animatorService;

        private Animator animatorController;

        void Start() {
            animatorService = animatorService ?? new AnimatorService();
            movementManager = GetComponent<MovementManager>();
            animatorController = GameObject.Find("SpriteRenderer").GetComponent<Animator>();
            SetAnimatorBoolTrue("Down");
        }

        public Animator GetAnimatorController() {
            return animatorController;
        }

        public void SetAnimatorController(Animator animator) {
            animatorController = animator;
        }


        public void SetAnimatorBoolTrue(string parameter) {
            animatorController.SetBool(parameter, true);
        }

        public void SetAnimatorBoolFalse(string parameter) {
            animatorController.SetBool(parameter, false);
        }

        public bool GetAnimatorBoolValue(string paramenter) {
            return animatorController.GetBool(paramenter);
        }
    }

}