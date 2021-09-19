using System;
using UnityEngine;

namespace TDS
{
    [RequireComponent(typeof(StatsComponent),
                      typeof(Animator),
                      typeof(SpriteRenderer))]
    public class Enemy : MonoBehaviour
    {
        [Header("Enemy Info")] 
        [SerializeField] private bool IsKillable;

        private StatsComponent stats;
        private SpriteRenderer sprite;
        private Animator animator;
        private string currentAnimState;

        public bool IsAttacking { get; private set; }
        
        private void Awake()
        {
            stats = GetComponent<StatsComponent>();
            sprite = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            currentAnimState = "Default";

            IsAttacking = false;
        }

        public void TakeDamage(int amount)
        {
            if (stats.IsDead || !IsKillable)
            {
                return;
            }
            
            // Flicker sprite
            
            stats.Health.TakeDamage(amount, stats.Defense.Value);
        }

        public void StartAttacking()
        {
            IsAttacking = true;
        }

        public void StopAttacking()
        {
            IsAttacking = false;
        }

        public void Death()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                var playerStats = other.GetComponent<StatsComponent>();
                playerStats.Health.TakeDamage(stats.Power.Value, playerStats.Defense.Value);
            }
        }

        public void ChangeAnimationState(string nextState)
        {
            if (nextState == currentAnimState)
            {
                return;
            }
            
            animator.Play(nextState);
            //Debug.Log(currentAnimState);
            currentAnimState = nextState;
        }
        
    }
}