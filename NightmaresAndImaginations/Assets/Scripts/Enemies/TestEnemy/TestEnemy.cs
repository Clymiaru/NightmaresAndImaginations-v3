using System;
using UnityEngine;

namespace TDS.AI
{
    public class TestEnemy : Enemy
    {
        [SerializeField] private float SightRange;

        [SerializeField] private SpriteRenderer Sprite;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, SightRange);
        }

        protected override void OnSpawn()
        {
        }

        protected override void OnDeath()
        {
        }
    }
}
