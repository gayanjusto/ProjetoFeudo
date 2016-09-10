using Assets.Scripts.Domain.Entities.CharacterManagement;

namespace Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation
{
    public interface IClassCreationManager
    {
        int CurrentClassId { get; set; }
        void ChangeClass(int classId);
        int GetPointPerSkill(int skillId);
        BaseClass GetChosenClass();
    }
}
