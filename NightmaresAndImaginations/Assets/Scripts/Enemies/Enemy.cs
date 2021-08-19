using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(StatsComponent))]
    public abstract class Enemy : MonoBehaviour
    {
        private StatsComponent stats;

        private void Awake()
        {
            stats = GetComponent<StatsComponent>();
        }

        private void Update()
        {
            if (!stats.IsDead)
                return;
            
            OnDeath();
        }

        protected abstract void OnSpawn();
        protected abstract void OnDeath();

        public void Spawn()
        {
            OnSpawn();
        }

        public void TakeDamage(int amount)
        {
            if (stats.IsDead)
            {
                return;
            }
            stats.Health.TakeDamage(amount);
        }

        public void DealDamage()
        {
            
        }
        
    }
}