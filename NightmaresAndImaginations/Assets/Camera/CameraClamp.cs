using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    public Transform toLookAt;
    public Vector3 offset;
    private float smoothFactor = 3;
    public Vector3 minValues, maxValues;

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(toLookAt.position.x + offset.x, minValues.x, maxValues.x),
            Mathf.Clamp(toLookAt.position.y + offset.y, minValues.y, maxValues.y),
            toLookAt.position.z + offset.z);
    }
}
