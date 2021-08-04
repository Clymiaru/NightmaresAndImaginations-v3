using System;
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

        protected abstract void OnSpawn();

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

            stats.Health -= amount;
        }
    }
}