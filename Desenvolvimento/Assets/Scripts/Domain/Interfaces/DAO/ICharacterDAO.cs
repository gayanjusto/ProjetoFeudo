using Assets.Scripts.Domain.DTO.CharacterCreation;

namespace ProjectFeudo.Domain.Interfaces.DAO
{
    public interface ICharacterDAO
    {
        void CreateCharacterJsonFile(CharacterCreationJsonDTO character);
        CharacterCreationJsonDTO GetCharacterData();
    }
}
