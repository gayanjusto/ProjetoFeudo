using UnityEngine;
using ProjectFeudo.Domain.Interfaces.Managers;

namespace ProjectFeudo.Managers
{
    public class AttackManager : BaseManager, IAttackManager
    {

        private bool isAttacking;
        private int attackSequence;

        public bool SetIsAttacking() {
            Debug.Log("teste");
            isAttacking = !isAttacking;

            return isAttacking;
        }

        public bool GetIsAttacking() {
            return isAttacking;
        }

        public int GetAttackSequence() {
            return attackSequence;
        }

        public void SetAttackSequence(int value) {
            attackSequence = value;
        }

        public bool Attack() {
            if (attackSequence < 3) {
                attackSequence++;
            } else {
                attackSequence = 0;
            }

            return true;
        }
    }

}