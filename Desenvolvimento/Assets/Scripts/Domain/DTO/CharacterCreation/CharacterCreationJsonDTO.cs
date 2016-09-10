using Assets.Scripts.Domain.Entities.CharacterManagement;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.DTO.CharacterCreation
{
    public class CharacterCreationJsonDTO
    {
        public string  Name { get; set; }
        public int Age { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public bool Gender { get; set; }

        public string HairStyleId { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }

        public CharacterCreationClassJsonDTO Class { get; set; }
        public IList<BaseSkill> Skills { get; set; }

    }
}
