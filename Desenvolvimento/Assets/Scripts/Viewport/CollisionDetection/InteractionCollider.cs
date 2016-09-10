using ProjectFeudo.Managers;
using UnityEngine;

namespace ProjectFeudo.Viewport
{
    public class InteractionCollider : MonoBehaviour
    {

        private InteractionManager interactionManager;

        void Start() {
            interactionManager = transform.parent.gameObject.GetComponent<InteractionManager>();
        }

        void OnTriggerEnter2D(Collider2D other) {
            Debug.Log("Entrou Colisão");
            interactionManager.KeepObjectInMemory(other.gameObject);
        }

        void OnTriggerExit2D(Collider2D other) {
            Debug.Log("Saiu Colisão");
            interactionManager.RemoveObjectInMemory(other.gameObject);
            interactionManager.CloseCurrentMenu();
        }
    }
}
