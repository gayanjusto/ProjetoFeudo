using Assets.Scripts.Domain.DTO.CharacterCreation;
using Assets.Scripts.Domain.Entities.CharacterManagement;
using Assets.Scripts.Domain.Enums.CharacterCreation;
using ProjectFeudo.DAO;
using ProjectFeudo.Domain.Creatures;
using ProjectFeudo.Domain.Interfaces.DAO;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts.Domain.Factories.CharacterCreation
{
    public class CharacterFactory
    {

        public static BaseCreature InstantiateCharacterFromJson(CharacterCreationJsonDTO charJsonData)
        {
            IEquippableItemDAO equippableItemDAO =  new EquippableItemDAO();

            BaseCreature character = new BaseCreature();
            character.Age = charJsonData.Age;
            character.Class = GetClassFromJson(charJsonData.Class);
            character.Skills = charJsonData.Skills;
           // character.Dexterity = charJsonData.Dexterity;
            character.Gender = charJsonData.Gender;
            character.HairColor = GetColorFromJson(charJsonData.HairColor);
            character.SkinColor = GetColorFromJson(charJsonData.SkinColor);
           // character.Skills = charJsonData.Skills;
            character.HairStyle = equippableItemDAO.GetItemById(charJsonData.HairStyleId);

            equippableItemDAO = null;

            return character;
        }

        static BaseClass GetClassFromJson(CharacterCreationClassJsonDTO classJson)
        {
            if(classJson.ClassId == (int)ClassIdEnum.Combatant)
            {
                return new CombatantClass();
            }

            if (classJson.ClassId == (int)ClassIdEnum.Wise)
            {
                return new WiseClass();
            }else
            {
                return new BurglarClass();
            }
        }

      
        static Color GetColorFromJson(string colorData)
        {
            string[] colorRGB = colorData.Split(';');

            float colorR = float.Parse(colorRGB[0]);
            float colorG = float.Parse(colorRGB[1]);
            float colorB = float.Parse(colorRGB[2]);

            return new Color(colorR, colorG, colorB);
        }
    }
}
