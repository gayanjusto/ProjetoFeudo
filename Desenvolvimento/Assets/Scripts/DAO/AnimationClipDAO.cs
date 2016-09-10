using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.Domain.Paths;
using ProjectFeudo.Services;
using System.Collections.Generic;
using UnityEngine;
using System;
using ProjectFeudo.Domain.Itens;

namespace ProjectFeudo.DAO
{
    public class AnimationClipDAO : IAnimationClipDAO
    {

        private static string mainFolder = "Animations/";
        private AnimationClip[] animationClips;
        private readonly AnimatorService animatorService;

        public AnimationClipDAO() {
            animatorService = new AnimatorService();
        }


        public AnimationClip[] GetItemAllDirectionByBodyPartClips(string race, EquippableItem item) {
            List<AnimationClip> animationClipList = new List<AnimationClip>();

            var directions = animatorService.GetAllDirections();

            foreach (var direction in directions) {
                animationClipList.AddRange(
                    GetClipsForAnimatorLayers(race,
                        AnimationResourcesPath.GetPath(item.ItemBodyPart),
                        AnimationResourcesPath.GetPath(item.ItemMaterial),
                        AnimationResourcesPath.GetPath(item.ItemResourcesPath),
                        AnimationResourcesPath.GetPath(direction)
                     ));
            }

            return animationClipList.ToArray();
        }

        public AnimationClip[] GetClipsForAnimatorLayers(string race, string bodyPart, string category, string itemFolder, string direction) {
            UnityEngine.Object[] animations = Resources.LoadAll(mainFolder + race + bodyPart + category + itemFolder + direction, typeof(AnimationClip));
            animationClips = new AnimationClip[animations.Length];

            for (int i = 0; i < animations.Length; i++) {
                animationClips[i] = (AnimationClip)animations[i];
            }
            return animationClips;
        }
    }

}