using UnityEngine;
using ProjectFeudo.Managers;

namespace ProjectFeudo.Viewport
{

    public class KeyboardInteractionInput : BaseInput
    {
        private InteractionManager interactionManager;
        private AttackManager attackManager;

        // Use this for initialization
        void Start() {
            interactionManager = GetComponent<InteractionManager>();
            attackManager = GetComponent<AttackManager>();
            base.keyPressDelay = 0.5f;
        }

        // Update is called once per frame
        void Update() {

            base.UpdateKeyPressIdleTime();

            if (Input.GetKeyDown(KeyCode.E) && TimeAfterKeyPressGreaterEqualThanKeyDelay()) {
                interactionManager.FilterInteractionByTag();
                ResetTimeAfterKeyPress();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && TimeAfterKeyPressGreaterEqualThanKeyDelay()) {
                interactionManager.CloseCurrentMenu();
                ResetTimeAfterKeyPress();
            }

            if (Input.GetKeyDown(KeyCode.I) && TimeAfterKeyPressGreaterEqualThanKeyDelay()) {
                interactionManager.OpenCloseInventoryMenu();
                ResetTimeAfterKeyPress();
            }

            if (Input.GetKeyDown(KeyCode.C) && TimeAfterKeyPressGreaterEqualThanKeyDelay()) {
                interactionManager.OpenCloseCharacterSheetMenu();
                ResetTimeAfterKeyPress();
            }

            if (Input.GetKey(KeyCode.Tab) && TimeAfterKeyPressGreaterEqualThanKeyDelay()) {
                attackManager.SetIsAttacking();
                ResetTimeAfterKeyPress();
            }
        }

    }
}
