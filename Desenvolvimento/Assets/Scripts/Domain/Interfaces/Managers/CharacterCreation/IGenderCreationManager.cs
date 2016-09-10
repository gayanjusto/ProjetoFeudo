namespace Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation
{
    public interface IGenderCreationManager
    {
        void ChangeGender(bool gender);
        bool GetGender();
    }
}
