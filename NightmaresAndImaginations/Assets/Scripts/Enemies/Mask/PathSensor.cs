using System;
using UnityEngine;

namespace TDS
{
    public class PathSensor : MonoBehaviour
    {
        private bool isBlocked;
        private bool isAtEdge;

        [Min(0.01f), SerializeField] 
        private float GroundDetectionDistance;
        
        [SerializeField] private LayerMask ObstaclesLayer;

        public bool IsBlocked => isBlocked || isAtEdge;

        private void Update()
        {
            var origin = transform.position;
            var edgeChecker = Physics2D.Raycast(origin, 
                                                Vector2.down, 
                                                GroundDetectionDistance, 
                                                ObstaclesLayer);
            
            isAtEdge = edgeChecker.collider == null;
            
            if (edgeChecker.collider != null &&
                edgeChecker.collider.gameObject.CompareTag("Player"))
            {
                isBlocked = true;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, Vector3.down * GroundDetectionDistance);
        }
    }
}
