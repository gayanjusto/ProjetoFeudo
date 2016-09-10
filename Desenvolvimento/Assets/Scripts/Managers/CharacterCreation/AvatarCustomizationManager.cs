using Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation;
using Assets.Scripts.Domain.Interfaces.Services;
using Assets.Scripts.Services;
using ProjectFeudo.DAO;
using ProjectFeudo.Domain.Interfaces.DAO;
using ProjectFeudo.Domain.Interfaces.Services;
using ProjectFeudo.Domain.Itens;
using ProjectFeudo.Managers;
using ProjectFeudo.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace Assets.Scripts.Managers.CharacterCreation
{
    public class AvatarCustomizationManager : BaseManager, IAvatarCustomizationManager
    {
        private GameObject playerObject;

        private SpriteRenderer playerHairSpriteRenderer;

        private IList<SpriteRenderer> playerBodyRenderersList;

        private IList<EquippableItem> hairList;
        private IList<EquippableItem> hairListByGender;
        private int currentHairIndex;

        private IList<Color> hairColorList;
        private int currentHairColorIndex;

        private IList<Color> skinColorList;
        private int currentSkinColorIndex;

        private IEquippableItemDAO equippableItemDAO;
        private IAnimationService animationService;
        private IColorService colorService;


        void Start() {
            playerObject = GameObject.Find("CharacterCreationAvatar");
            playerBodyRenderersList = new List<SpriteRenderer>();
            GetPlayerBodyRenderers();

            animationService = animationService ?? new AnimationService();
            equippableItemDAO = equippableItemDAO ?? new EquippableItemDAO();
            colorService = colorService ?? new ColorService();

            hairList = equippableItemDAO.GetAllFromSpecificFile("hair", ".json").ToList();

            hairColorList = colorService.GetHairColorList();
            skinColorList = colorService.GetSkinColorList();

            currentHairColorIndex = 0;
            currentSkinColorIndex = 0;
            currentHairIndex = 0;
        }

        void GetPlayerBodyRenderers() {
            playerHairSpriteRenderer = playerObject.transform.Find("SpriteRenderer/HairRender")
               .GetComponent<SpriteRenderer>();

            playerBodyRenderersList.Add(playerObject.transform.Find("SpriteRenderer/HeadRender")
              .GetComponent<SpriteRenderer>());

            playerBodyRenderersList.Add(playerObject.transform.Find("SpriteRenderer/ChestRender")
              .GetComponent<SpriteRenderer>());

            playerBodyRenderersList.Add(playerObject.transform.Find("SpriteRenderer/RightArmRender")
              .GetComponent<SpriteRenderer>());

            playerBodyRenderersList.Add(playerObject.transform.Find("SpriteRenderer/RightHandRender")
              .GetComponent<SpriteRenderer>());

            playerBodyRenderersList.Add(playerObject.transform.Find("SpriteRenderer/RightFootRender")
              .GetComponent<SpriteRenderer>());

            playerBodyRenderersList.Add(playerObject.transform.Find("SpriteRenderer/LegsRender")
              .GetComponent<SpriteRenderer>());

            playerBodyRenderersList.Add(playerObject.transform.Find("SpriteRenderer/LeftArmRender")
             .GetComponent<SpriteRenderer>());

            playerBodyRenderersList.Add(playerObject.transform.Find("SpriteRenderer/LeftHandRender")
              .GetComponent<SpriteRenderer>());

            playerBodyRenderersList.Add(playerObject.transform.Find("SpriteRenderer/LeftFootRender")
              .GetComponent<SpriteRenderer>());
        }
        public void PreviousHairStyle() {
            currentHairIndex--;
            if (currentHairIndex < 0) {
                currentHairIndex = 0;
            }

            ChangeHairStyle();
        }

        public void NextHairStyle() {
            currentHairIndex++;
            if (currentHairIndex > hairListByGender.Count -1) {
                currentHairIndex = 0;
            }

            ChangeHairStyle();
        }

        void ChangeHairStyle() {

            EquippableItem newHair = hairListByGender[currentHairIndex];

            animationService.ChangeAnimationClipsByBodyPart(playerObject.GetComponent<AnimationManager>(), newHair);
        }

    

        public void PreviousHairColor() {
            currentHairColorIndex--;
            if(currentHairColorIndex < 0) {
                currentHairColorIndex = 0;
            }

            ChangeHairColor();
        }

        public void NextHairColor() {
            currentHairColorIndex++;
            if (currentHairColorIndex > hairColorList.Count - 1) {
                currentHairColorIndex = 0;
            }

            ChangeHairColor();
        }

        void ChangeHairColor() {
            playerHairSpriteRenderer.color = hairColorList[currentHairColorIndex];
        }

        public void PreviousSkinColor() {
            currentSkinColorIndex--;
            if (currentSkinColorIndex < 0) {
                currentSkinColorIndex = 0;
            }

            ChangeSkinColor();
        }

        public void NextSkinColor() {
            currentSkinColorIndex++;
            if (currentSkinColorIndex > skinColorList.Count - 1) {
                currentSkinColorIndex = 0;
            }

            ChangeSkinColor();
        }

        public void ChangeSkinColor() {
            foreach (var bodyRenderPart in playerBodyRenderersList) {
                bodyRenderPart.color = skinColorList[currentSkinColorIndex];
            }
        }

        public Color GetHairColor()
        {
            return this.hairColorList[currentHairColorIndex];
        }

        public Color GetSkinColor()
        {
            return this.skinColorList[currentSkinColorIndex];
        }

        public EquippableItem GetHairStyle()
        {
            return hairListByGender[currentHairIndex];
        }

        public void LoadHairByGender(bool gender)
        {
            if (gender){  //Male
                hairListByGender = hairList.Where(x => x.Name.Contains("Male")).ToList();
            }else{
                hairListByGender = hairList.Where(x => x.Name.Contains("Female")).ToList();
            }
        }
    }
}
