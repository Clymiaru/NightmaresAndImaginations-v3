using UnityEngine;

namespace TDS.AI
{
    public class IsPathBlockedNode : DecoratorNode
    {
        private PathSensor sensor;
        
        public IsPathBlockedNode(Node child, Enemy owner, PathSensor sensor) : base(child, owner)
        {
            this.sensor = sensor;
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            var isPathBlocked = sensor.IsBlocked;

            if (!isPathBlocked) return State.Failure;
            
            Child.Update();
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}

