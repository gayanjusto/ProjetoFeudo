using System;
using Assets.Scripts.Domain.Entities.CharacterManagement;
using Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation;
using ProjectFeudo.Domain.Creatures;
using ProjectFeudo.Domain.Itens;
using ProjectFeudo.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts.Domain.Interfaces.Services;
using Assets.Scripts.Services;
using System.Collections.Generic;
using System.Text;

namespace Assets.Scripts.Managers.CharacterCreation
{
    public class CharacterCreationManager : BaseManager, ICharacterCreationManager
    {
        public BaseCreature character;

        private ISkillsCreationManager skillCreationManager;
        private IClassCreationManager classCreationManager;
        private ICharacterCreationService characterCreationService;
        private IAvatarCustomizationManager avatarCustomizationManager;
        private IGenderCreationManager genderCreationManager;
        private IAttributeManager attributeManager;

        private GameObject messagePanel;
        private Vector2 messagePanelOriginalPosition;

        void Awake()
        {
            messagePanel = GameObject.Find("MessagePanel");
            messagePanelOriginalPosition = messagePanel.GetComponent<RectTransform>().anchoredPosition;
            HideMessagePanel();

            skillCreationManager = this.GetComponent<ISkillsCreationManager>();
            classCreationManager = this.GetComponent<IClassCreationManager>();
            avatarCustomizationManager = this.GetComponent<IAvatarCustomizationManager>();
            attributeManager = this.GetComponent<IAttributeManager>();
            genderCreationManager = this.GetComponent<IGenderCreationManager>();

            characterCreationService = characterCreationService ?? new CharacterCreationService();
            character = character ?? new BaseCreature();
        }

        public void FinishCreation() {

           List<string> validationMessages = ValidateCreationForm();

            if(validationMessages.Count > 0)
            {
                SetValidationMessages(validationMessages);
                ShowMessagePanel();
                return;
            }

            characterCreationService.CreateCharacterJsonFile(GetCharacterProperties());

           // SceneManager.LoadScene("FirstScene");
        }

        BaseCreature GetCharacterProperties()
        {
            character.Name = GetCharacterName();
            character.Age = GetCharacterAge();
            character.Skills = skillCreationManager.GetSkillsWithPoints();
            character.Class = classCreationManager.GetChosenClass();
            character.HairColor = avatarCustomizationManager.GetHairColor();
            character.SkinColor = avatarCustomizationManager.GetSkinColor();
            character.Intelligence = attributeManager.GetIntelligencePoints();
            character.Strength = attributeManager.GetStrengthPoints();
            character.Dexterity = attributeManager.GetDexterityPoints();
            character.Gender = genderCreationManager.GetGender();
            character.HairStyle = avatarCustomizationManager.GetHairStyle();

            return character;
        }

        public void SetCharacterClass(BaseClass chosenClass)
        {
            character.Class = chosenClass;
        }

        public void SetCharacterHairColor(Color hairColor)
        {
            this.character.HairColor = hairColor;
        }

        public void SetCharacterHairStyle(EquippableItem hairStyle)
        {
            this.character.HairStyle = hairStyle;
        }

        public void SetCharacterSkinColor(Color skinColor)
        {
            this.character.SkinColor = skinColor;
        }

        public void HideMessagePanel()
        {
            messagePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(1000, messagePanelOriginalPosition.y);
        }


        string GetCharacterName()
        {
            return GameObject.Find("Canvas").transform.Find("ContainerPanel/CharacterDefinitionsPanel/NameInput/Text").GetComponent<Text>().text;
        }

        int GetCharacterAge()
        {
            var ageValue = GameObject.Find("Canvas/ContainerPanel/CharacterDefinitionsPanel/AgeInput/Text").GetComponent<Text>().text;

            return String.IsNullOrEmpty(ageValue) ? 0 : Convert.ToInt32(ageValue);
        }


     
        void ShowMessagePanel()
        {
            messagePanel.GetComponent<RectTransform>().anchoredPosition = messagePanelOriginalPosition;
        }

        List<string> ValidateCreationForm()
        {
            List<string> errorMessages = new List<string>();

            if (skillCreationManager.GetRemainingPoints() != 0)
            {
                errorMessages.Add("There are skill points remaining.");
            }

            if (String.IsNullOrEmpty(GetCharacterName()))
            {
                errorMessages.Add("Character name cannot be empty.");
            }

            if (GetCharacterAge() == 0)
            {
                errorMessages.Add("Character age cannot be empty.");
            }

            return errorMessages;
        }

        void SetValidationMessages(IList<string> validationMessages)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string message in validationMessages)
            {
                sb.Append(" ♦ " + message + "\r\n");
            }

            var text = messagePanel.transform.FindChild("Text").GetComponent<Text>();
            text.text = sb.ToString();
        }
    }
}
