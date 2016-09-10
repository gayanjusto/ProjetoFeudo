using Assets.Scripts.Domain.Entities.CharacterManagement;
using ProjectFeudo.Domain.Itens;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectFeudo.Domain.Creatures
{
    public class BaseCreature
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public EquippableItem HairStyle { get; set; }

        public Color HairColor { get; set; }

        public Color SkinColor { get; set; }

        public bool Gender { get; set; }

        public BaseClass Class { get; set; }

        public IList<BaseSkill> Skills { get; set; }
    }
}

