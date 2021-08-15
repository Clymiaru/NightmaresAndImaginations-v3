using UnityEditor;
using UnityEngine;

namespace TDS.AI
{
    [CustomEditor (typeof (Sensor))]
    public class SensorEditor : Editor 
    {
        private void OnSceneGUI() 
        {
            var sensor = (Sensor)target;
            var sensorPosition = sensor.transform.position;

            //Draws view reach
            Handles.color = Color.yellow;
            Handles.DrawWireArc(sensorPosition, Vector3.forward, Vector3.up, 360, sensor.Radius);

            //Draws cone of view
            var viewAngleA = sensor.DirectionFromAngle(-sensor.Angle / 2, false);
            var viewAngleB = sensor.DirectionFromAngle(sensor.Angle / 2, false);

            Handles.DrawLine(sensorPosition, sensorPosition + viewAngleA * sensor.Radius);
            Handles.DrawLine(sensorPosition, sensorPosition + viewAngleB * sensor.Radius);
        }
    }
}

