using Assets.Scripts.Domain.Entities.CharacterManagement;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.DTO.CharacterCreation
{
    public class CharacterCreationClassJsonDTO
    {
        public int ClassId { get; set; }

        public string ClassName { get; set; }

        public IList<BaseSkill> ClassSkills { get; set; }
    }
}
