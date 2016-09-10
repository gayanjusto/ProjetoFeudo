using System;
using Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation;
using ProjectFeudo.Managers;
using System.Collections.Generic;
using Assets.Scripts.Domain.Enums.CharacterCreation;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.Managers.CharacterCreation
{
    public class AttributeManager : BaseManager, IAttributeManager
    {
        public int AttributePoints { get; set; }
        private Dictionary<int, int> attributePointDictionary;

        private Text attributePointText;
        private Text strengthText;
        private Text dexterityText;
        private Text intelligenceText;

        void Awake() {
            FillAttributeDictionary();
            GetAttributeTexts();
            AttributePoints = 15;
        }

        void Update() {
            UpdateAttributesText();
        }

        public void DecreaseAttribute(int attributeId) {
            if (CanReduceAttribute(attributeId)) {
                attributePointDictionary[attributeId] -= 1;
                AttributePoints++;
            }
        }

        public bool HasPointsToUse() {
            return AttributePoints > 0;
        }

        public void IncreaseAttribute(int attributeId) {
            if (CanIncreaseAttribute(attributeId)) {
                attributePointDictionary[attributeId] += 1;
                AttributePoints--;
            }
        }

        private bool CanIncreaseAttribute(int attributeId) {
            return attributePointDictionary[attributeId] < 10 && HasPointsToUse();
        }

        private bool CanReduceAttribute(int attributeId) {
            return attributePointDictionary[attributeId] > 0 && AttributePoints < 15;
        }

        private void FillAttributeDictionary() {
            attributePointDictionary = new Dictionary<int, int>();

            int initialPoints = 0;
            attributePointDictionary.Add(AttributeIdEnum.Strength.GetHashCode(), initialPoints);
            attributePointDictionary.Add(AttributeIdEnum.Dexterity.GetHashCode(), initialPoints);
            attributePointDictionary.Add(AttributeIdEnum.Intelligence.GetHashCode(), initialPoints);
        }

        void GetAttributeTexts() {
            GameObject characterDefinitionPanel = GameObject.Find("Canvas/ContainerPanel/CharacterDefinitionsPanel");

            attributePointText = characterDefinitionPanel.transform.Find("AttributesPointsLabel")
                .GetComponent<Text>();

            strengthText = characterDefinitionPanel.transform.Find("StrengthPointsLabel")
                .GetComponent<Text>();

            dexterityText = characterDefinitionPanel.transform.Find("DexterityPointsLabel")
                .GetComponent<Text>();

            intelligenceText = characterDefinitionPanel.transform.Find("IntelligencePointsLabel")
                .GetComponent<Text>();

        }

        void UpdateAttributesText() {
            attributePointText.text = AttributePoints.ToString();
            strengthText.text = "[" + attributePointDictionary[AttributeIdEnum.Strength.GetHashCode()] + "]";
            dexterityText.text = "[" + attributePointDictionary[AttributeIdEnum.Dexterity.GetHashCode()] + "]";
            intelligenceText.text = "[" + attributePointDictionary[AttributeIdEnum.Intelligence.GetHashCode()] + "]";
        }

        public int GetIntelligencePoints()
        {
            return attributePointDictionary[AttributeIdEnum.Intelligence.GetHashCode()];
        }

        public int GetStrengthPoints()
        {
            return attributePointDictionary[AttributeIdEnum.Strength.GetHashCode()];
        }

        public int GetDexterityPoints()
        {
            return attributePointDictionary[AttributeIdEnum.Dexterity.GetHashCode()];
        }
    }
}
