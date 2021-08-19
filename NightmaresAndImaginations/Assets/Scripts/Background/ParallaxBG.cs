using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS {
    public class ParallaxBG : MonoBehaviour
    {
        [SerializeField] private float parallaxEffectMultiplier;

        private Transform cameraTransform;
        private Vector3 lastCameraPostion;

        private void Start()
        {
            cameraTransform = Camera.main.transform;
            lastCameraPostion = cameraTransform.position;
        }

        private void LateUpdate()
        {
            Vector3 deltaMovement = cameraTransform.position - lastCameraPostion;
            
            transform.position += deltaMovement * parallaxEffectMultiplier;
            lastCameraPostion = cameraTransform.position;
        }



    }
}



