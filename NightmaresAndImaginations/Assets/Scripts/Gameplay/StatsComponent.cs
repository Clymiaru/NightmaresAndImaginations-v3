using UnityEngine;

namespace TDS
{
    public class StatsComponent : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        private int currentHealth;

        [SerializeField] private int defense;
        [SerializeField] private int power;
        [SerializeField] private int movementSpeed;

        public int MaxHealth => maxHealth;
        public int Health => currentHealth;
        public int Defense => defense;
        public int MovementSpeed => movementSpeed;
        public bool IsDead => currentHealth <= 0;

        private void OnValidate()
        {
            maxHealth = Mathf.Max(maxHealth, 0);
            defense = Mathf.Max(defense, 0);
            power = Mathf.Max(power, 0);
            movementSpeed = Mathf.Max(movementSpeed, 0);
        }
    }
}

