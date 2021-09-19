using UnityEngine;

namespace TDS
{
    public class BumpInTheNightProjectile : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other != null)
            {
                if (other.CompareTag("Enemy"))
                {
                    return;
                }
                
                if (other.CompareTag("Player"))
                {
                    // Player takes damage
                    var playerStats = other.GetComponent<StatsComponent>();
                    playerStats.Health.TakeDamage(5, playerStats.Defense.Value);
                }
            
                // SFX Hit projectile
                Destroy(gameObject);    
            }
            
        }
    }
}

