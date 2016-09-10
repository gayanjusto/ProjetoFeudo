using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Managers;
using UnityEngine;

namespace ProjectFeudo.Viewport
{

    public class MouseInput : BaseInput, IAttackTimer
    {
        private IPlayerManager playerManager;
        private IAttackManager attackManager;

        private const int LeftMouseButton = 0;
        private const int RightMouseButton = 1;
        private const int MiddleMouseButton = 2;

        public float AttackSequenceDelayTime { get; set; }

        public bool IsOnAttackSequence { get; set; }

        public float TimeIdleAttack { get; set; }

        void Start() {
            playerManager = GetComponent<PlayerManager>();
            attackManager = GetComponent<AttackManager>();

            base.keyPressDelay = playerManager.GetAvatar().GetAttackDelay();

            AttackSequenceDelayTime = base.keyPressDelay + .3f;

        }
        // Update is called once per frame
        void Update() {

            base.UpdateKeyPressIdleTime();

            if (IsOnAttackSequence) {
                UpdateAttackSequenceDelayTime();
                if (TimeIdleAttack >= AttackSequenceDelayTime) {
                    ResetAttackSequeceAfterDelay();
                }
            }
            if (Input.GetMouseButton(LeftMouseButton) && base.TimeAfterKeyPressGreaterEqualThanKeyDelay()) {
                if (attackManager.GetIsAttacking()) {
                    Debug.Log("Attacked");
                    attackManager.Attack();
                    ResetTimeIdleAttack();
                    IsOnAttackSequence = true;
                }

                ResetTimeAfterKeyPress();
            }

            if (Input.GetMouseButton(RightMouseButton) && base.TimeAfterKeyPressGreaterEqualThanKeyDelay()) {
                Debug.Log("Right Mouse Button");
                if (attackManager.GetIsAttacking()) {
                    Debug.Log("Defended");
                }

                ResetTimeAfterKeyPress();
            }

            if (Input.GetMouseButton(MiddleMouseButton) && base.TimeAfterKeyPressGreaterEqualThanKeyDelay()) {
                Debug.Log("Middle Mouse Button");

                ResetTimeAfterKeyPress();
            }
        }

        public void ResetAttackSequeceAfterDelay() {
            Debug.Log("Attack Delay Time is Up!");
            IsOnAttackSequence = false;
            ResetTimeIdleAttack();
            attackManager.SetAttackSequence(0);
        }

        public void UpdateAttackSequenceDelayTime() {
            TimeIdleAttack += Time.deltaTime;
        }

        public void ResetTimeIdleAttack() {
            TimeIdleAttack = 0;
        }
    }
}
