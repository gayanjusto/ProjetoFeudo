using ProjectFeudo.Domain.Itens;
using UnityEngine;

namespace Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation
{
    public interface IAvatarCustomizationManager
    {
        void PreviousHairStyle();
        void NextHairStyle();
        void PreviousHairColor();
        void NextHairColor();
        void PreviousSkinColor();
        void NextSkinColor();

        Color GetHairColor();
        Color GetSkinColor();
        EquippableItem GetHairStyle();
        void LoadHairByGender(bool gender);
    }
}
