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
                    var playerStats = other.GetComponent<PlayerResponse>();
                    playerStats.TakeDamage(5, transform.position.x);
                }
            
                // SFX Hit projectile
                Destroy(gameObject);    
            }
            
        }
    }
}

