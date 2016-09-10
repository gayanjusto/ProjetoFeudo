using Assets.Scripts.Domain.Enums.CharacterCreation;

namespace Assets.Scripts.Domain.Entities.CharacterManagement
{
    public class WiseClass : BaseClass
    {
        public WiseClass() {
            ClassId = ClassIdEnum.Wise.GetHashCode();
        }

        public override int GetPointsPerSkill(int skillId) {
            if (skillId >= SkillIdEnum.BladedWeapons.GetHashCode() && skillId <= SkillIdEnum.Defense.GetHashCode()) {
                return 3;
            } else if (skillId >= SkillIdEnum.Healing.GetHashCode() && skillId <= SkillIdEnum.History.GetHashCode()) {
                return 1;
            } else { //Burglar Skills
                return 2;
            }
        }
    }
}
