using System;
using UnityEngine;

namespace TDS.AI
{
    public class RaycastSensor : MonoBehaviour
    {
        [SerializeField] private LayerMask EnemyLayer;
        private void Update()
        {
            var origin = transform.position;
            var hit = Physics2D.Raycast(origin, 
                                        Vector2.down,
                                        Mathf.Infinity, 
                                        EnemyLayer);
#if DEBUG
            Debug.DrawRay(origin, 
                          Vector2.down * hit.distance, 
                          Color.yellow);
            if (hit.collider != null)
            {
                Debug.Log(name + " Enemy found");
            }
#endif
        }
    }
}

