using Assets.Scripts.Domain.Enums.CharacterCreation;

namespace Assets.Scripts.Domain.Entities.CharacterManagement
{
    public class CombatantClass : BaseClass
    {
        public CombatantClass() {
            ClassId = ClassIdEnum.Combatant.GetHashCode();
        }

        public override int GetPointsPerSkill(int skillId) {
            if (skillId >= SkillIdEnum.BladedWeapons.GetHashCode() && skillId <= SkillIdEnum.Defense.GetHashCode()) {
                return 1;
            }else if (skillId >= SkillIdEnum.Healing.GetHashCode() && skillId <= SkillIdEnum.History.GetHashCode()) {
                return 2;
            }
            else { //Burglar Skills
                return 3;
            }
        }
    }
}
