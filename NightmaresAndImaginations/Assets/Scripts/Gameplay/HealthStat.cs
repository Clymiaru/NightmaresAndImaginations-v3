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
        
        public void TakeDamage(int enemyPower, int userDefense)
        {
            // Damage calculation
            int damage = 0;
            if (userDefense >= enemyPower)
                damage = 1;
            else
                damage = enemyPower;

            BaseValue -= damage;
            Debug.Log($"Health: {BaseValue}");
        }

        public void Restore(int healAmount)
        {
            BaseValue = Mathf.Min(BaseValue + healAmount, maxValue);
        }
    }

}
