using Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation;
using ProjectFeudo.Managers;

namespace Assets.Scripts.Managers.CharacterCreation
{
    public class GenderCreationManager : BaseManager, IGenderCreationManager
    {
        //True: Male | False: Female
        private bool gender;
        private IAvatarCustomizationManager avatarCustomizationManager;
        void Start()
        {
            gender = true;
            avatarCustomizationManager = this.GetComponent<IAvatarCustomizationManager>();
        }

        public void ChangeGender(bool gender)
        {
            this.gender = gender;
            LoadHairListBasedOnGender();
        }

        public bool GetGender()
        {
            return gender;
        }

        void LoadHairListBasedOnGender()
        {
            avatarCustomizationManager.LoadHairByGender(this.gender);
        }
    }
}
