using System;
using System.Collections.Generic;
using Assets.Scripts.Domain.Entities.CharacterManagement;
using Assets.Scripts.Domain.Interfaces.DAO;
using ProjectFeudo.DAO;

namespace Assets.Scripts.DAO
{
    public class SkillDAO : BaseDAO<BaseSkill>, ISkillDAO
    {
        public SkillDAO()
        {
            base.AssetsFolder = "/Skills/";
        }
        public IEnumerable<BaseSkill> GetAllSkills()
        {
            return base.GetAllFromSpecificFile("skills", ".json");
        }
    }
}
