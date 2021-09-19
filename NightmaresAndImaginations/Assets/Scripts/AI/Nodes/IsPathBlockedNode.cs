using UnityEngine;

namespace TDS.AI
{
    public class IsPathBlockedNode : DecoratorNode
    {
        private PathSensor sensor;
        
        public IsPathBlockedNode(PathSensor sensor, Node child, Enemy owner) : base(child, owner)
        {
            this.sensor = sensor;
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            var isPathBlocked = sensor.IsBlocked;

            if (!isPathBlocked)
            {
                return State.Failure;
            }
            
            
            Debug.Log("Path is blocked!");
            
            return Child.Update();
        }

        protected override void OnStop()
        {
        }
    }
}

