using UnityEngine;

namespace ProjectFeudo.Viewport
{

    public abstract class BaseInput : MonoBehaviour
    {
        protected float keyPressDelay; //0.5 second
        protected float timeIdleAfterKeyPress;

        protected bool TimeAfterKeyPressGreaterEqualThanKeyDelay() {
            return timeIdleAfterKeyPress >= keyPressDelay;
        }

        protected void ResetTimeAfterKeyPress() {
            timeIdleAfterKeyPress = 0f;
        }

        protected void UpdateKeyPressIdleTime() {
            timeIdleAfterKeyPress += Time.deltaTime;
        }
    }
}
