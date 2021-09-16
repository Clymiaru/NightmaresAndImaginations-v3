using System.Reflection;
using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(StatsComponent),
                      typeof(Animator),
                      typeof(SpriteRenderer))]
    public abstract class Enemy : MonoBehaviour
    {
        private StatsComponent stats;
        private string currentState;
        private Animator animator;
        private SpriteRenderer sprite;

        private void Awake()
        {
            stats = GetComponent<StatsComponent>();
            animator = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
            currentState = "Default";
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
            if (nextState == currentState)
            animator.Play(nextState);
        }
        
    }
}