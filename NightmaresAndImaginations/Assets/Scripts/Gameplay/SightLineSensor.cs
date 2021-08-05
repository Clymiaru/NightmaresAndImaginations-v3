using UnityEngine;

namespace TDS
{
    public class SightLineSensor : MonoBehaviour
    {
        [SerializeField] private float TargetSightRange;
        [SerializeField] private Vector2 SightDirection;
        [SerializeField] private string LayerOfTarget;
        [SerializeField] private string TagOfTarget;
        
        private GameObject sightedTarget = null;

        public Vector2 GetDirection()
        {
            return SightDirection;
        }
        public void FlipDirection()
        {
            SightDirection *= -1;
        }
        
        public bool IsTargetWithinSight()
        {
            Vector2 currPos = transform.position;
            
            var hit = Physics2D.Raycast(currPos, SightDirection, TargetSightRange, 1 << LayerMask.NameToLayer(LayerOfTarget));

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag(TagOfTarget))
                {
                    sightedTarget = hit.collider.gameObject;
                    return true;
                }
            }

            sightedTarget = null;
            return false;
        }

        public GameObject RetriveSightedTarget()
        {
            return sightedTarget;
        }

        private void DebugTargetSightRange()
        {
            Vector2 currPos = transform.position;
            var endPos =  currPos + SightDirection * TargetSightRange;
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(currPos, endPos);
        }

        private void OnDrawGizmos()
        {
            DebugTargetSightRange();
        }
    }
}
