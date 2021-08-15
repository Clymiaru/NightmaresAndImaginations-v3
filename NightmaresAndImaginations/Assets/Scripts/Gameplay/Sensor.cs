using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class Sensor : MonoBehaviour
    {
        [SerializeField] private float ViewRadius;
        [SerializeField] private float ViewAngle;
        [SerializeField] private LayerMask TargetsLayer;
        [SerializeField] private LayerMask ObstaclesLayer;

        public float Radius => ViewRadius;
        public float Angle => ViewAngle;

        public List<GameObject> VisibleTargets { get; private set; } = new List<GameObject>();

        public void FindVisibleTargets() 
        {
            VisibleTargets.Clear();
            
            var position = transform.position;

            var targetsInViewRadius = Physics2D.OverlapCircleAll(position, ViewRadius, TargetsLayer);
            
            foreach (var targetCollider in targetsInViewRadius)
            {
                var target = targetCollider.gameObject;
                var targetTransform = target.transform;
                var dirToTarget = (target.transform.position - transform.position).normalized;

                if (Vector3.Angle(transform.up, dirToTarget) > ViewAngle / 2)
                {
                    return;
                }
                
                var distanceToTarget = Vector3.Distance(position, targetTransform.position);

                var hit = Physics2D.Raycast(position,
                                            dirToTarget,
                                            distanceToTarget,
                                            ObstaclesLayer);
                if (!hit) 
                {
                    VisibleTargets.Add(target);
                }
            }
        }
        
        public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees -= transform.eulerAngles.z;
            }
            
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),
                               Mathf.Cos(angleInDegrees * Mathf.Deg2Rad),
                               0);
        }
        
    }
}
