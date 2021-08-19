using System;
using UnityEngine;

namespace TDS
{
    public class PathSensor : MonoBehaviour
    {
        // TODO: Crowd management
        
        private bool isBlocked;
        private bool isAtEdge;

        [Min(0.01f), SerializeField] 
        private float groundDetectionDistance;
        
        [SerializeField] private LayerMask ObstaclesLayer;

        public bool IsBlocked => isBlocked || isAtEdge;

        private void Update()
        {
            var hit = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionDistance, ObstaclesLayer);
            isAtEdge = !hit.collider;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                isBlocked = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                isBlocked = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(transform.position, Vector3.down * groundDetectionDistance);
        }
    }
}
