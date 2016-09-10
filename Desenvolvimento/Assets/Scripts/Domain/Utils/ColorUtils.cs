using UnityEngine;

namespace Assets.Scripts.Domain.Utils
{
    public static class ColorUtils
    {
        public static float GetColorValueFrom255Standard(float value) {
            return value / 255;
        }

        public static Color GetRGBColorFrom255Standard(float r, float g, float b) {
            return new Color(r / 255, g / 255, b / 255);
        }
    }
}
