using Assets.Scripts.Domain.Entities.CharacterManagement;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Interfaces.Services
{
    public interface ISkillsService
    {
        IList<BaseSkill> GetAllSkills();
    }
}
