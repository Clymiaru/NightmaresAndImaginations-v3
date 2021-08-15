using UnityEngine;

namespace TDS.AI
{
    public class IsPathBlockedNode : DecoratorNode
    {
        private Sensor sensor;
        
        public IsPathBlockedNode(Node child, Sensor sensor) : base(child)
        {
            this.sensor = sensor;
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            sensor.FindVisibleTargets();

            var isPathBlocked = sensor.VisibleTargets.Count > 0;

            if (!isPathBlocked) return State.Failure;
            
            Child.Update();
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}

