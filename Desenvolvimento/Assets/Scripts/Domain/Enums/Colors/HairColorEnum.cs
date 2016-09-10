using Assets.Scripts.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Domain.Enums.Colors
{
    public static class HairColorEnum
    {
        public static Color lightBrownHairColor = ColorUtils.GetRGBColorFrom255Standard(110, 82, 45);
        public static Color darkBrownHairColor = ColorUtils.GetRGBColorFrom255Standard(46, 17, 9);
        public static Color redHairColor = ColorUtils.GetRGBColorFrom255Standard(179, 54, 20);
        public static Color blackHairColor = ColorUtils.GetRGBColorFrom255Standard(28, 12, 7);
    }
}
