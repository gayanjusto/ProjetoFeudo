using System;
using Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation;
using ProjectFeudo.Managers;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.Managers.CharacterCreation
{
    public class AgeManager : BaseManager, IAgeManager
    {
        private InputField ageField;

        void Start() {
            ageField = GameObject.Find("Canvas/ContainerPanel/CharacterDefinitionsPanel/AgeInput")
                .GetComponent<InputField>();

            ageField.onValueChanged.AddListener(delegate { ValueChangedCheck(); });
        }

        public void ValueChangedCheck() {
            if(ageField.text.Length > 1) {
                int ageValue = Convert.ToInt16(ageField.text);
                if (ageValue < 16) {
                    ageField.text = "16";
                    return;
                }

                if (ageValue > 60) {
                    ageField.text = "60";
                    return;
                }
            }
           
        }
    }
}
