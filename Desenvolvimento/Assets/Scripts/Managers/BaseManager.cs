using ProjectFeudo.Domain.Interfaces.Managers;
using UnityEngine;

namespace ProjectFeudo.Managers
{

    public class BaseManager : MonoBehaviour, IBaseManager
    {

        public GameObject GetRootGameObject() {
            return gameObject.transform.root.gameObject;
        }
    }

}