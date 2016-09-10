using Assets.Scripts.Domain.Entities.CharacterManagement;
using ProjectFeudo.Domain.Itens;
using UnityEngine;

namespace Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation
{
    public interface ICharacterCreationManager
    {
        void SetCharacterClass(BaseClass chosenClass);
        void SetCharacterHairStyle(EquippableItem hairStyle);
        void SetCharacterHairColor(Color hairColor);
        void SetCharacterSkinColor(Color skinColor);

        void FinishCreation();
        void HideMessagePanel();
    }
}
