using System;
using ProjectFeudo.Domain.Creatures;
using ProjectFeudo.Domain.Interfaces.Managers;

namespace ProjectFeudo.Managers
{
    public class PlayerManager : BaseManager, IPlayerManager
    {
        public Human humanAvatar;

        void Awake() {
            humanAvatar = humanAvatar ?? new Human();
            DontDestroyOnLoad(this);
        }

        public Human GetAvatar() {
            return humanAvatar;
        }
    }
}
