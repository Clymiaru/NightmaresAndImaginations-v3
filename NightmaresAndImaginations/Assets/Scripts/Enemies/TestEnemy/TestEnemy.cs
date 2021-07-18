using System;
using UnityEngine;

namespace TDS.AI
{
    public class TestEnemy : Enemy
    {
        [SerializeField] private float SightRange;
        [SerializeField] private ParticleSystem DespawnVFX;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, SightRange);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(DespawnVFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        protected override void OnSpawn()
        {
        }
    }
}
