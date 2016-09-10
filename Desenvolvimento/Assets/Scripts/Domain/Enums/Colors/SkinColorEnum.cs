using Assets.Scripts.Domain.Utils;
using UnityEngine;

namespace Assets.Scripts.Domain.Enums.Colors
{
    public static class SkinColorEnum
    {
        public static Color paleSkinColor = ColorUtils.GetRGBColorFrom255Standard(245, 239, 196);
        public static Color darkSkinColor = ColorUtils.GetRGBColorFrom255Standard(92, 58, 4);
        public static Color chocolateSkinColor = ColorUtils.GetRGBColorFrom255Standard(138, 96, 29);
        public static Color yellowSkinColor = ColorUtils.GetRGBColorFrom255Standard(255, 243, 150);
    }
}
