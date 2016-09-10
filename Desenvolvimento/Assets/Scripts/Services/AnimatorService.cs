using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using ProjectFeudo.Domain.Enums;

namespace ProjectFeudo.Services
{
    public class AnimatorService
    {
        public AnimatorOverrideController OverrideAnimatorController(RuntimeAnimatorController runtimeAnimatorController,
            AnimationClip[] newAnimationClips)
        {

            AnimatorOverrideController currentAnimatorController = runtimeAnimatorController as AnimatorOverrideController;
            AnimatorOverrideController newOverrideController = new AnimatorOverrideController();

            if (currentAnimatorController != null) //Use existing overrideController
            {
                RuntimeAnimatorController originalRuntimeController = currentAnimatorController.runtimeAnimatorController;
                newOverrideController.runtimeAnimatorController = originalRuntimeController;
            }else //If there's no existing overrideController, use a new one
            {
                newOverrideController.runtimeAnimatorController = runtimeAnimatorController;
            }
         

            foreach (var animation in runtimeAnimatorController.animationClips)
            {

                var equivalentAnimation = GetClipFromOriginalAnimator(animation.name, newAnimationClips);

                if (equivalentAnimation == null)
                    newOverrideController[animation.name] = animation;
                else
                    newOverrideController[animation.name] = equivalentAnimation;
            }

            //Dispose pointer: Unity known issue.
            runtimeAnimatorController = null;

            return newOverrideController;
        }

        /*
        <summary>
        This method will compare if identifiable name of an original animation name is 
        equivalent to any from a list of new ones by their overridable codes, splitting by "_":
        
        Ex: head_shortHair -> will override any animation that has "head_" in its name.


        </summary>
        */
        AnimationClip GetClipFromOriginalAnimator(string originalAnimationName, AnimationClip[] newAnimationClips)
        {
            return newAnimationClips.FirstOrDefault(x => x.name.Split('_')[0]
            .Equals(originalAnimationName.Split('_')[0]));
        }

        public IEnumerable<string> GetAllBodyParts()
        {
            var bodyPartsList = new List<string>();

            bodyPartsList.Add(ItemBodyPartEnum.Chest);
            bodyPartsList.Add(ItemBodyPartEnum.Head);

            bodyPartsList.Add(ItemBodyPartEnum.LeftArm);
            bodyPartsList.Add(ItemBodyPartEnum.LeftFoot);
            bodyPartsList.Add(ItemBodyPartEnum.LeftHand);
            bodyPartsList.Add(ItemBodyPartEnum.LeftLeg);

            bodyPartsList.Add(ItemBodyPartEnum.RightArm);
            bodyPartsList.Add(ItemBodyPartEnum.RightFoot);
            bodyPartsList.Add(ItemBodyPartEnum.RightHand);
            bodyPartsList.Add(ItemBodyPartEnum.RightLeg);

            return bodyPartsList;
        }

        public IEnumerable<string> GetAllDirections()
        {
            var directionList = new List<string>();

            directionList.Add(DirectionAnimationEnum.Up);
            directionList.Add(DirectionAnimationEnum.Right);
            directionList.Add(DirectionAnimationEnum.Down);
            directionList.Add(DirectionAnimationEnum.Left);

            return directionList;
        }
    }
}
