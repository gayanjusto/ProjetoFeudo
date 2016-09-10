using Assets.Scripts.Domain.Enums.CharacterCreation;

namespace Assets.Scripts.Domain.Entities.CharacterManagement
{
    public class BurglarClass : BaseClass
    {
        public BurglarClass() {
            ClassId = ClassIdEnum.Burglar.GetHashCode();
        }
        public override int GetPointsPerSkill(int skillId) {
            if (skillId >= SkillIdEnum.BladedWeapons.GetHashCode() && skillId <= SkillIdEnum.Defense.GetHashCode()) {
                return 2;
            } else if (skillId >= SkillIdEnum.Healing.GetHashCode() && skillId <= SkillIdEnum.History.GetHashCode()) {
                return 3;
            } else { //Burglar Skills
                return 1;
            }
        }
    }
}
