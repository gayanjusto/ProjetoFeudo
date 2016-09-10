using UnityEngine;
using System.Collections;


namespace ProjectFeudo.Managers
{
    public class GameApplicationManager : MonoBehaviour
    {

        void Awake() {
            Application.targetFrameRate = 300;
        }
    }
}


