using UnityEngine;

namespace TDS
{
    public class HealthStat : UnitStat
    {
        private readonly int maxValue;

        public HealthStat(int maxHealth) : base(maxHealth)
        {
            this.maxValue = maxHealth;
        }
        
        public void TakeDamage(int enemyPower)
        {
            // Damage calculation
            BaseValue -= enemyPower;
        }

        public void Restore(int healAmount)
        {
            BaseValue = Mathf.Min(BaseValue + healAmount, maxValue);
        }
    }

}
