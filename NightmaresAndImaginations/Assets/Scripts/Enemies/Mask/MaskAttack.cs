using System;
using UnityEngine;

namespace TDS
{
    public class MaskAttack : MonoBehaviour
    {
        [SerializeField] private StatsComponent maskStats;
        private GameObject target;

        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        public void Attack()
        {
            Debug.Log("Activate!");
            var playerStats = target.GetComponent<StatsComponent>();
            playerStats.Health.TakeDamage(maskStats.Power.Value, playerStats.Defense.Value);
            Debug.Log("Damaged!");
        }
    }
}
