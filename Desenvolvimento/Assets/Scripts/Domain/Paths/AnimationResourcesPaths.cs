
using ProjectFeudo.Domain.Enums;

namespace ProjectFeudo.Domain.Paths
{
    public static class AnimationRaceResourcesPath
    {
        public static string humanoid = "Humanoid/";
    }

    public static class AnimationResourcesPath
    {
        public static string GetPath(string location) {
            return location + "/";
        }
    }
}


