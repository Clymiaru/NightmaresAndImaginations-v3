using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(StatsComponent),
                      typeof(Animator),
                      typeof(SpriteRenderer))]
    public abstract class Enemy : MonoBehaviour
    {
        private StatsComponent stats;

        private SpriteRenderer sprite;

        private Animator animator;
        private string currentAnimState;

        private void Awake()
        {
            stats = GetComponent<StatsComponent>();
            sprite = GetComponent<SpriteRenderer>();
            
            animator = GetComponent<Animator>();
            currentAnimState = "Default";
        }

        private void Update()
        {
            if (!stats.IsDead)
                return;

            OnDeath();
        }

        protected abstract void OnDeath();

        public void TakeDamage(int amount)
        {
            if (stats.IsDead)
            {
                return;
            }
            
            // Flicker sprite
            
            stats.Health.TakeDamage(amount, stats.Defense.Value);
        }

        public void Death()
        {
            Destroy(gameObject);
        }

        public void ChangeAnimationState(string nextState)
        {
            if (nextState == currentAnimState)
            {
                return;
            }
            
            animator.Play(nextState);

            currentAnimState = nextState;
        }
        
    }
}