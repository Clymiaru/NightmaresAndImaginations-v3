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
            var playerStats = target.GetComponent<PlayerResponse>();
            playerStats.TakeDamage(maskStats.Power.Value, transform.position.x);
            Debug.Log("Damaged!");
        }
    }
}
