using System.Collections.Generic;

namespace Assets.Scripts.Domain.Entities.CharacterManagement
{
    public abstract class BaseClass {

        public int ClassId {get; set;}

        public IList<BaseSkill> ClassSkills { get; set; }

        public abstract int GetPointsPerSkill(int skillId);
    }
}
