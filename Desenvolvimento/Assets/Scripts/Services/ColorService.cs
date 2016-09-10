using Assets.Scripts.Domain.Enums.Colors;
using Assets.Scripts.Domain.Interfaces.Services;
using Assets.Scripts.Domain.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Services
{
    public class ColorService : IColorService
    {
        public IList<Color> GetHairColorList() {
            IList<Color> hairColorList = new List<Color>();

            hairColorList.Add(HairColorEnum.lightBrownHairColor);
            hairColorList.Add(HairColorEnum.darkBrownHairColor);
            hairColorList.Add(HairColorEnum.redHairColor);
            hairColorList.Add(HairColorEnum.blackHairColor);

            return hairColorList;
        }

        public IList<Color> GetSkinColorList() {
            IList<Color> skinColorLIst = new List<Color>();

            skinColorLIst.Add(SkinColorEnum.paleSkinColor);
            skinColorLIst.Add(SkinColorEnum.darkSkinColor);
            skinColorLIst.Add(SkinColorEnum.chocolateSkinColor);
            skinColorLIst.Add(SkinColorEnum.yellowSkinColor);

            return skinColorLIst;
        }
    }
}
