using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class TargetPositionChecker : MonoBehaviour
    {
        private GameObject target;

        public Vector3 DirectionOffset { get; private set; }
        
        private Vector3 storedPosition;
        
        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player");
            storedPosition = target.transform.position;
        }

        private void Update()
        {
            if (target.transform.position != storedPosition)
            {
                DirectionOffset = (target.transform.position - storedPosition).normalized;
                storedPosition = target.transform.position;
            }
            else
            {
                DirectionOffset = Vector3.zero;
            }
        }
    }

}
