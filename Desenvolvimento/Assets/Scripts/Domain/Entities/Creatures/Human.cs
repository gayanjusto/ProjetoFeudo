
namespace ProjectFeudo.Domain.Creatures
{

    public class Human : BaseCreature
    {
        public Human() {
            Intelligence = 10;
            Strength = 2;
            Dexterity = 1;
            Stamina = GetMaximumStamina();
        }


        public string Name { get; set; }

        public bool Gender { get; set; }

        public int Age { get; set; }

        public int Intelligence { get; set; }

        public int Dexterity { get; set; }

        public int Strength { get; set; }

        public int Defense { get; set; }

        public int Stamina { get; set; }

        public int GetMaximumStamina() {
            return (Strength * Dexterity) * 3;
        }

        public bool CanRun() {
            return Stamina > GetMaximumStamina() / 4;
        }

        public int GetSecondsToRecoverFullStamina() {
            return (GetMaximumStamina() / Dexterity) * 2;
        }

        public int GetTotalPointsToRecoverPerTick() {
            return (Strength + Dexterity) / 2;
        }

        public void RecoverStaminaPoints() {
            if (Stamina + GetTotalPointsToRecoverPerTick() > GetMaximumStamina()) {
                Stamina = GetMaximumStamina();
                return;
            }

            Stamina += GetTotalPointsToRecoverPerTick();
        }

        //1f = 1 second
        //f(x) = -Dexterity + 15
        public float GetAttackDelay() {
            return (float)((Dexterity * -1) + 15) / 10;
        }
    }
}


