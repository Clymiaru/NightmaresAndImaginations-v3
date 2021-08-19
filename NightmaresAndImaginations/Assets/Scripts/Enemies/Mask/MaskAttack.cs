using UnityEngine;

namespace TDS
{
    public class MaskAttack : MonoBehaviour
    {
        private BoxCollider2D collider;

        private bool isAttacking = false;
        [SerializeField]
        private float attackInterval = 1.0f;
        
        private float currentTime;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                return;
            }
            
            isAttacking = true;
            currentTime = attackInterval;
            Debug.Log($"Attacking Player! {other.gameObject.name}");
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!isAttacking)
                return;
            
            if (currentTime > attackInterval)
            {
                var enemyStats = other.gameObject.GetComponent<StatsComponent>();
                enemyStats.Health.TakeDamage(10, 10);
                Debug.Log($"Hit! {enemyStats.Health.Value}");
                currentTime = 0.0f;
                return;
            }

            currentTime += Time.deltaTime;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            currentTime = 0.0f;
            isAttacking = false;
            Debug.Log("Not Attacking Player!");
        }
    }

}
