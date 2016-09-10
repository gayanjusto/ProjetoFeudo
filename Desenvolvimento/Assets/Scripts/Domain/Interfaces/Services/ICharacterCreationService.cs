using ProjectFeudo.Domain.Creatures;

namespace Assets.Scripts.Domain.Interfaces.Services
{
    public interface ICharacterCreationService
    {
        void CreateCharacterJsonFile(BaseCreature character);
        BaseCreature GetCharacterData();
    }
}
