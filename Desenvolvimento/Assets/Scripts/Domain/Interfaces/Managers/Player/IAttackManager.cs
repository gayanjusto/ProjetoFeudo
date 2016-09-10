
namespace ProjectFeudo.Domain.Interfaces.Managers
{
    public interface IAttackManager
    {
        bool SetIsAttacking();
        bool GetIsAttacking();
        int GetAttackSequence();
        void SetAttackSequence(int value);
        bool Attack();
    }
}


