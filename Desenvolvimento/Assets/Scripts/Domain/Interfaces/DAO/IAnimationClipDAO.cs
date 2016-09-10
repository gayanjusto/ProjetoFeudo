using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Itens;
using UnityEngine;

namespace ProjectFeudo.Domain.Interfaces.DAO
{
    public interface IAnimationClipDAO
    {
        AnimationClip[] GetClipsForAnimatorLayers(string race, string itemBodyPart, string itemMaterial, string itemFolder, string direction);
        AnimationClip[] GetItemAllDirectionByBodyPartClips(string race, EquippableItem item);
    }
}


