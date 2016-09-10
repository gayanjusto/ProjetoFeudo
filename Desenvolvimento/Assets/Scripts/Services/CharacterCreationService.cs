using Assets.Scripts.Domain.Interfaces.Services;
using ProjectFeudo.Domain.Creatures;
using Assets.Scripts.DAO;
using ProjectFeudo.Domain.Interfaces.DAO;
using Assets.Scripts.Domain.DTO.CharacterCreation;
using Assets.Scripts.Domain.Factories.CharacterCreation;

namespace Assets.Scripts.Services
{
    public class CharacterCreationService : ICharacterCreationService
    {
        private readonly ICharacterDAO characterDAO;

        public CharacterCreationService()
        {
            characterDAO = characterDAO ?? new CharacterDAO();
        }

        public void CreateCharacterJsonFile(BaseCreature character)
        {
            CharacterCreationJsonDTO characterDTO = new CharacterCreationJsonDTO();

            characterDTO.Name = character.Name;
            characterDTO.Age = character.Age;

            characterDTO.Strength = character.Strength;
            characterDTO.Intelligence = character.Intelligence;
            characterDTO.Dexterity = character.Dexterity;

            characterDTO.Gender = character.Gender;

            characterDTO.HairStyleId = character.HairStyle.Id;
            characterDTO.HairColor = (character.HairColor.r + ";" + character.HairColor.g + ";" + character.HairColor.b);
            characterDTO.SkinColor = (character.SkinColor.r + ";" + character.SkinColor.g + ";" + character.SkinColor.b);

            characterDTO.Skills = character.Skills;
            characterDTO.Class = ClassJsonDTOFactory.InstantiateDtoClassFromBaseClass(character.Class);

            characterDAO.CreateCharacterJsonFile(characterDTO);
        }

        public BaseCreature GetCharacterData()
        {
            var charData = characterDAO.GetCharacterData();

           return  CharacterFactory.InstantiateCharacterFromJson(charData);
        }
    }
}
