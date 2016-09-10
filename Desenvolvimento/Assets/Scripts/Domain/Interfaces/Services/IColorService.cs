using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Domain.Interfaces.Services
{
    public interface IColorService
    {
        IList<Color> GetHairColorList();
        IList<Color> GetSkinColorList();
    }
}
