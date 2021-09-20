using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class BossMovement : MonoBehaviour
    {
        private GameObject target;
        private Vector2 deltaDirection;
        private Vector2 previousPosition;
        [SerializeField] private Mover mover;

        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player");
            previousPosition = target.transform.position;
        }

        private void Update()
        {
            deltaDirection = (target.transform.position - gameObject.transform.position).normalized;
            deltaDirection.y = 0;
            
            if(Mathf.Approximately(Vector2.Distance(gameObject.transform.position, target.transform.position), 
                                   0.0f))
            {
                deltaDirection = Vector2.zero;
            }
            
            Debug.Log($"X {deltaDirection.x} Y: {deltaDirection.y}");
            

            mover.Move(deltaDirection);
        }
    }
}

