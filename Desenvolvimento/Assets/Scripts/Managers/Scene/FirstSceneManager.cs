using System;
using Assets.Scripts.Domain.Interfaces.Managers.Scene;
using ProjectFeudo.Managers;
using Assets.Scripts.Domain.Interfaces.Services;
using Assets.Scripts.Services;

namespace Assets.Scripts.Managers.Scene
{
    public class FirstSceneManager : BaseManager, IFirstSceneManager
    {
        private ICharacterCreationService characterCreationService;

        void Awake()
        {
            characterCreationService = characterCreationService ?? new CharacterCreationService();
            LoadCharacterData();
        }

        public void LoadCharacterData()
        {
            characterCreationService.GetCharacterData();
        }
    }
}
