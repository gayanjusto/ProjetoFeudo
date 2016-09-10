using Assets.Scripts.Domain.Entities.CharacterManagement;
using System.Collections.Generic;

namespace Assets.Scripts.Domain.Interfaces.Managers.CharacterCreation
{
    public interface ISkillsCreationManager
    {
        void IncreaseRemainingSkillPoints(int points);
        void DecreaseRemainingSkillPoints(int points);
        bool HasPointsToUse();

        void IncreaseSkillPoint(int skillId);
        void DecreaseSkillPoint(int skillId);

        void ResetPoints();
        void ChangeSkillTextColorFromClass(int classId);

        int GetRemainingPoints();

        IList<BaseSkill> GetSkillsWithPoints();
    }
}
