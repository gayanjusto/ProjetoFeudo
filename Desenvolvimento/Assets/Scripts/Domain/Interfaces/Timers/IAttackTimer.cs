namespace ProjectFeudo.Domain.Interfaces.Services
{
    public interface IAttackTimer
    {
        float AttackSequenceDelayTime { get; set; }

        float TimeIdleAttack { get; set; }

        bool IsOnAttackSequence { get; set; }

        void ResetAttackSequeceAfterDelay();

        void ResetTimeIdleAttack();

        void UpdateAttackSequenceDelayTime();
    }
}


