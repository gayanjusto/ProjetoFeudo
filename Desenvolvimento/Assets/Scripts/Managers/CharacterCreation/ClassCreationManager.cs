using System;
using Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation;
using ProjectFeudo.Managers;
using Assets.Scripts.Domain.Entities.CharacterManagement;
using Assets.Scripts.Domain.Enums.CharacterCreation;
using UnityEngine;

namespace Assets.Scripts.Managers.CharacterCreation
{
    public class ClassCreationManager : BaseManager, IClassCreationManager {

        public int CurrentClassId {get; set;}
        public ICharacterCreationManager characterCreationManager;
        private BaseClass chosenClass;
        private ISkillsCreationManager skillCreationManager;

        void Start() {
            characterCreationManager = GameObject.Find("CharacterCreationManager").GetComponent<ICharacterCreationManager>();
            skillCreationManager = gameObject.GetComponent<ISkillsCreationManager>();
            ChangeClass(ClassIdEnum.Combatant.GetHashCode());
        }

        public void ChangeClass(int classId) {
            skillCreationManager.ResetPoints();

            skillCreationManager.ChangeSkillTextColorFromClass(classId);

            if(classId == ClassIdEnum.Combatant.GetHashCode()) {
                chosenClass = new CombatantClass();
                characterCreationManager.SetCharacterClass(chosenClass);

                return;
            }

            if (classId == ClassIdEnum.Wise.GetHashCode()) {
                chosenClass = new WiseClass();
                return;
            }

            if (classId == ClassIdEnum.Burglar.GetHashCode()) {
                chosenClass = new BurglarClass();
                return;
            }
        }

        public int GetPointPerSkill(int skillId) {
            return chosenClass.GetPointsPerSkill(skillId);
        }

        public BaseClass GetChosenClass()
        {
            return this.chosenClass;
        }
    }
}
