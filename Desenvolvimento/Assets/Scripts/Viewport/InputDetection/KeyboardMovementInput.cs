using UnityEngine;
using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Managers;

namespace ProjectFeudo.Viewport
{

    public class KeyboardMovementInput : MonoBehaviour
    {
        private IMovementManager movementManager;

        // Use this for initialization
        void Start() {
            movementManager = gameObject.GetComponent<MovementManager>();
        }

        // Update is called once per frame
        void Update() {
            GetMovementInput();
            GetRunningInput();
        }


        void MovementInputPressed(KeyCode key) {
            movementManager.InsertKeyIntoInputList(key);
        }

        void MovementInputRelease(KeyCode key) {
            movementManager.RemoveKeyIntoInputList(key);
        }

        void GetRunningInput() {
            if (Input.GetKey(KeyCode.LeftShift)) {
                movementManager.SetIsRunning(true);
            }

            if (Input.GetKeyUp(KeyCode.LeftShift)) {
                movementManager.SetIsRunning(false);
            }
        }
        void GetMovementInput() {
            if (Input.GetKey(KeyCode.W)) {
                MovementInputPressed(KeyCode.W);
            }

            if (Input.GetKeyUp(KeyCode.W)) {
                MovementInputRelease(KeyCode.W);
            }

            if (Input.GetKey(KeyCode.S)) {
                MovementInputPressed(KeyCode.S);
            }

            if (Input.GetKeyUp(KeyCode.S)) {
                MovementInputRelease(KeyCode.S);
            }


            if (Input.GetKey(KeyCode.D)) {
                MovementInputPressed(KeyCode.D);
            }

            if (Input.GetKeyUp(KeyCode.D)) {
                MovementInputRelease(KeyCode.D);
            }

            if (Input.GetKey(KeyCode.A)) {
                MovementInputPressed(KeyCode.A);
            }

            if (Input.GetKeyUp(KeyCode.A)) {
                MovementInputRelease(KeyCode.A);
            }
        }

    }

}