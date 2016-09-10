using Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation;
using ProjectFeudo.Managers;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Domain.Enums.CharacterCreation;
using Assets.Scripts.Domain.Entities.CharacterManagement;
using Assets.Scripts.Domain.Interfaces.Services;
using Assets.Scripts.Services;
using System.Linq;
using System;

namespace Assets.Scripts.Managers.CharacterCreation
{

    public class SkillsCreationManager : BaseManager, ISkillsCreationManager
    {
        private Text pointsText;
        private int remainingPoints;
        private IClassCreationManager classCreationManager;
        private ISkillsService skillsService;
        private Dictionary<int, int> skillPointDictionary;
        private IList<BaseSkill> skills;

        Color primarySkillColor = Color.green;
        Color secondarySkillColor = Color.yellow;
        Color tertiarySkillColor = Color.red;

        /* Skills Points Label Text */
        Text primaryLabelText;
        Text secondaryLabelText;
        Text tertiaryLabelText;

        /* Skills Text */
        IList<Text> combatSkillLabelTextList;
        IList<Text> wiseSkillLabelTextList;
        IList<Text> burglarSkillLabelTextList;

        private Text bladedWeaponText;
        private Text bluntWeaponText;
        private Text archeryText;
        private Text defenseText;

        private Text healingText;
        private Text musicText;
        private Text sorceryText;
        private Text historyText;

        private Text lockpicksText;
        private Text stealingText;
        private Text disguiseText;
        private Text trapsText;

        /* Points Text */
        private Text bladedWeaponPointsText;
        private Text bluntWeaponPointsText;
        private Text archeryPointsText;
        private Text defensePointsText;

        private Text healingPointsText;
        private Text musicPointsText;
        private Text sorceryPointsText;
        private Text historyPointsText;

        private Text lockpicksPointsText;
        private Text stealingPointsText;
        private Text disguisePointsText;
        private Text trapsPointsText;



        void Start() {
            combatSkillLabelTextList = new List<Text>();
            wiseSkillLabelTextList = new List<Text>();
            burglarSkillLabelTextList = new List<Text>();

            FillSkillDictionary();
            GetAllTextsFromHierarchy();
            classCreationManager = gameObject.GetComponent<IClassCreationManager>();
            remainingPoints = 50;
            pointsText.text = remainingPoints.ToString();

            skillsService = skillsService ?? new SkillsService();
            skills = skillsService.GetAllSkills();
        }

        void Update() {
            UpdateCombatantPointsText();
            UpdateWisePointsText();
            UpdateBurglarPointsText();
        }

        public void IncreaseSkillPoint(int skillId) {
            if (CanIncreasePoint(skillId)) {
                skillPointDictionary[skillId] += 1;

                int points = GetPointToApplyFromClass(skillId);
                DecreaseRemainingSkillPoints(points);
            }

        }

        public void DecreaseSkillPoint(int skillId) {
            if (CanDecreasePoints(skillId)) {
                skillPointDictionary[skillId] -= 1;

                int points = GetPointToApplyFromClass(skillId);
                IncreaseRemainingSkillPoints(points);
            }

        }

        public void DecreaseRemainingSkillPoints(int points) {
            if (remainingPoints > 0)
                remainingPoints -= points;

            pointsText.text = remainingPoints.ToString();
        }

        public void IncreaseRemainingSkillPoints(int points) {
            if (remainingPoints < 50)
                remainingPoints += points;

            pointsText.text = remainingPoints.ToString();
        }

        public bool HasPointsToUse() {
            return remainingPoints > 0;
        }

        private bool CanIncreasePoint(int skillId) {
            int points = GetPointToApplyFromClass(skillId);
            return (remainingPoints - points >= 0 && skillPointDictionary[skillId] < 10);
        }

        private bool CanDecreasePoints(int skillId) {
            int points = GetPointToApplyFromClass(skillId);
            return (remainingPoints + points >= 0 && skillPointDictionary[skillId] > 0);
        }

        private void FillSkillDictionary() {
            skillPointDictionary = new Dictionary<int, int>();
            int initialSkillPoint = 0;

            /* COMBATANT */
            skillPointDictionary.Add(SkillIdEnum.BladedWeapons.GetHashCode(), initialSkillPoint);
            skillPointDictionary.Add(SkillIdEnum.BluntWeapons.GetHashCode(), initialSkillPoint);
            skillPointDictionary.Add(SkillIdEnum.Archery.GetHashCode(), initialSkillPoint);
            skillPointDictionary.Add(SkillIdEnum.Defense.GetHashCode(), initialSkillPoint);

            /* WISE */
            skillPointDictionary.Add(SkillIdEnum.Healing.GetHashCode(), initialSkillPoint);
            skillPointDictionary.Add(SkillIdEnum.Music.GetHashCode(), initialSkillPoint);
            skillPointDictionary.Add(SkillIdEnum.Sorcery.GetHashCode(), initialSkillPoint);
            skillPointDictionary.Add(SkillIdEnum.History.GetHashCode(), initialSkillPoint);

            /* BURGLAR */
            skillPointDictionary.Add(SkillIdEnum.Lockpicks.GetHashCode(), initialSkillPoint);
            skillPointDictionary.Add(SkillIdEnum.Stealing.GetHashCode(), initialSkillPoint);
            skillPointDictionary.Add(SkillIdEnum.Disguise.GetHashCode(), initialSkillPoint);
            skillPointDictionary.Add(SkillIdEnum.Traps.GetHashCode(), initialSkillPoint);

        }

        private void GetAllTextsFromHierarchy() {
            GameObject skillPanel = GameObject.Find("Canvas/ContainerPanel/SkillsPanel");

            pointsText = skillPanel.transform.FindChild("RemainingPointsLabel")
                .GetComponent<Text>();



            primaryLabelText = skillPanel.transform.FindChild("PrimaryLabel")
              .GetComponent<Text>();
            primaryLabelText.color = primarySkillColor;

            secondaryLabelText = skillPanel.transform.FindChild("SecondaryLabel")
                .GetComponent<Text>();
            secondaryLabelText.color = secondarySkillColor;


            tertiaryLabelText = skillPanel.transform.FindChild("TertiaryLabel")
                .GetComponent<Text>();
            tertiaryLabelText.color = tertiarySkillColor;


            /* COMBATANT */
            combatSkillLabelTextList.Add(skillPanel.transform.FindChild("BladedWeaponSkillLabel")
                .GetComponent<Text>());
            bladedWeaponPointsText = skillPanel.transform.FindChild("BladedWeaponPointsLabel")
                .GetComponent<Text>();

            combatSkillLabelTextList.Add(skillPanel.transform.FindChild("BluntWeaponSkillLabel")
                .GetComponent<Text>());
            bluntWeaponPointsText = skillPanel.transform.FindChild("BluntWeaponPointsLabel")
                .GetComponent<Text>();

            combatSkillLabelTextList.Add(skillPanel.transform.FindChild("ArcherySkillLabel")
                .GetComponent<Text>());
            archeryPointsText = skillPanel.transform.FindChild("ArcheryPointsLabel")
                .GetComponent<Text>();


            combatSkillLabelTextList.Add(skillPanel.transform.FindChild("DefenseSkillLabel")
                .GetComponent<Text>());
            defensePointsText = skillPanel.transform.FindChild("DefensePointsLabel")
                .GetComponent<Text>();

            /* WISE */
            wiseSkillLabelTextList.Add(skillPanel.transform.FindChild("HealingSkillLabel")
              .GetComponent<Text>());
            healingPointsText = skillPanel.transform.FindChild("HealingPointsLabel")
              .GetComponent<Text>();

            wiseSkillLabelTextList.Add(skillPanel.transform.FindChild("MusicSkillLabel")
                .GetComponent<Text>());
            musicPointsText = skillPanel.transform.FindChild("MusicPointsLabel")
                .GetComponent<Text>();

            wiseSkillLabelTextList.Add(skillPanel.transform.FindChild("SorcerySkillLabel")
                .GetComponent<Text>());
            sorceryPointsText = skillPanel.transform.FindChild("SorceryPointsLabel")
                .GetComponent<Text>();

            wiseSkillLabelTextList.Add(skillPanel.transform.FindChild("HistorySkillLabel")
                .GetComponent<Text>());
            historyPointsText = skillPanel.transform.FindChild("HistoryPointsLabel")
                .GetComponent<Text>();

            /* BURGLAR */
            burglarSkillLabelTextList.Add(skillPanel.transform.FindChild("LockpicksSkillLabel")
                .GetComponent<Text>());
            lockpicksPointsText = skillPanel.transform.FindChild("LockpicksPointsLabel")
                .GetComponent<Text>();

            burglarSkillLabelTextList.Add(skillPanel.transform.FindChild("StealingSkillLabel")
                .GetComponent<Text>());
            stealingPointsText = skillPanel.transform.FindChild("StealingPointsLabel")
                .GetComponent<Text>();

            burglarSkillLabelTextList.Add(skillPanel.transform.FindChild("DisguiseSkillLabel")
                .GetComponent<Text>());
            disguisePointsText = skillPanel.transform.FindChild("DisguisePointsLabel")
                .GetComponent<Text>();

            burglarSkillLabelTextList.Add(skillPanel.transform.FindChild("TrapsSkillLabel")
                .GetComponent<Text>());
            trapsPointsText = skillPanel.transform.FindChild("TrapsPointsLabel")
                .GetComponent<Text>();

        }

        private void UpdateCombatantPointsText() {
            bladedWeaponPointsText.text = "[" + skillPointDictionary[SkillIdEnum.BladedWeapons.GetHashCode()] + "]";
            bluntWeaponPointsText.text = "[" + skillPointDictionary[SkillIdEnum.BluntWeapons.GetHashCode()] + "]";
            archeryPointsText.text = "[" + skillPointDictionary[SkillIdEnum.Archery.GetHashCode()] + "]";
            defensePointsText.text = "[" + skillPointDictionary[SkillIdEnum.Defense.GetHashCode()] + "]";
        }

        private void UpdateWisePointsText() {

            healingPointsText.text = "[" + skillPointDictionary[SkillIdEnum.Healing.GetHashCode()] + "]";
            musicPointsText.text = "[" + skillPointDictionary[SkillIdEnum.Music.GetHashCode()] + "]";
            sorceryPointsText.text = "[" + skillPointDictionary[SkillIdEnum.Sorcery.GetHashCode()] + "]";
            historyPointsText.text = "[" + skillPointDictionary[SkillIdEnum.History.GetHashCode()] + "]";
        }

        private void UpdateBurglarPointsText() {

            lockpicksPointsText.text = "[" + skillPointDictionary[SkillIdEnum.Lockpicks.GetHashCode()] + "]";
            stealingPointsText.text = "[" + skillPointDictionary[SkillIdEnum.Stealing.GetHashCode()] + "]";
            disguisePointsText.text = "[" + skillPointDictionary[SkillIdEnum.Disguise.GetHashCode()] + "]";
            trapsPointsText.text = "[" + skillPointDictionary[SkillIdEnum.Traps.GetHashCode()] + "]";
        }

        private int GetPointToApplyFromClass(int skillId) {
            return classCreationManager.GetPointPerSkill(skillId);
        }

        public void ResetPoints() {
            remainingPoints = 50;
            pointsText.text = remainingPoints.ToString();
            FillSkillDictionary();
        }

        public void ChangeSkillTextColorFromClass(int classId)
        {
          

            if (classId == ClassIdEnum.Combatant.GetHashCode())
            {
                ChangeCombatSkillLabelColor(primarySkillColor);
                ChangeWisekillLabelColor(secondarySkillColor);
                ChangeBurglarSkillLabelColor(tertiarySkillColor);

                return;
            }

            if (classId == ClassIdEnum.Wise.GetHashCode())
            {
                ChangeCombatSkillLabelColor(tertiarySkillColor);
                ChangeWisekillLabelColor(primarySkillColor);
                ChangeBurglarSkillLabelColor(secondarySkillColor);

                return;
            }

            if (classId == ClassIdEnum.Burglar.GetHashCode())
            {
                ChangeCombatSkillLabelColor(secondarySkillColor);
                ChangeWisekillLabelColor(tertiarySkillColor);
                ChangeBurglarSkillLabelColor(primarySkillColor);

                return;
            }
        }

        void ChangeCombatSkillLabelColor(Color color)
        {
            foreach (var skillLabel in combatSkillLabelTextList)
            {
                skillLabel.color = color;
            }
        }

        void ChangeWisekillLabelColor(Color color)
        {
            foreach (var skillLabel in wiseSkillLabelTextList)
            {
                skillLabel.color = color;
            }
        }

        void ChangeBurglarSkillLabelColor(Color color)
        {
            foreach (var skillLabel in burglarSkillLabelTextList)
            {
                skillLabel.color = color;
            }
        }

        public int GetRemainingPoints()
        {
            return this.remainingPoints;
        }

        public IList<BaseSkill> GetSkillsWithPoints()
        {
            foreach (var skill in skills)
            {
                skill.Points = skillPointDictionary[skill.SkillId];
            }

            return skills;
        }
    }
}
