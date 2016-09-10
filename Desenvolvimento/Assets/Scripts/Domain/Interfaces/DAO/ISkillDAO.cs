using Assets.Scripts.Domain.Entities.CharacterManagement;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Interfaces.DAO
{
    public interface ISkillDAO
    {
        IEnumerable<BaseSkill> GetAllSkills();
    }
}
