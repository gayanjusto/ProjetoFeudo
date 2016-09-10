using System;
using System.Collections.Generic;
using Assets.Scripts.Domain.Entities.CharacterManagement;
using Assets.Scripts.Domain.Interfaces.Services;
using Assets.Scripts.Domain.Interfaces.DAO;
using Assets.Scripts.DAO;
using System.Linq;

namespace Assets.Scripts.Services
{
    public class SkillsService : ISkillsService
    {
        private readonly ISkillDAO skillDAO;

        public SkillsService()
        {
            skillDAO = skillDAO ?? new SkillDAO();
        }
        public IList<BaseSkill> GetAllSkills()
        {
            return skillDAO.GetAllSkills().ToList();
        }
    }
}
