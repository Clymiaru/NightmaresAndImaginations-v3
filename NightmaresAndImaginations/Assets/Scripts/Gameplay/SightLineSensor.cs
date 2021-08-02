using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class SightLineSensor : MonoBehaviour
    {
        [SerializeField] private float SightRange;
        
        
        public bool IsTargetWithinSight()
        {
            Vector2 currPos = transform.position;
            
            var endPos =  currPos + Vector2.left * SightRange;

            var hit = Physics2D.Raycast(currPos, Vector2.left, SightRange, 1 << LayerMask.NameToLayer("Player"));
            // var hit = Physics2D.Linecast(currPos, endPos, 1 << LayerMask.NameToLayer("Player"));

            if (hit.collider == null)
                return false;
            
            return hit.collider.gameObject.CompareTag("Player");
        }

        private void OnDrawGizmos()
        {  
            Vector2 currPos = transform.position;
            var endPos =  currPos + Vector2.left * SightRange;
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(currPos, endPos);
        }
    }
}
