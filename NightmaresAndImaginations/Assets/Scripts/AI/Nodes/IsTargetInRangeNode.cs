using UnityEngine;

namespace TDS.AI
{
    public class IsTargetInRangeNode : DecoratorNode
    {
        private readonly Sensor sensor;
        
        public IsTargetInRangeNode(Node child, Enemy owner, Sensor sensor) : base(child, owner)
        {
            this.sensor = sensor;
        }

        protected override void OnStart()
        {
            
        }

        protected override State OnUpdate()
        {
            sensor.FindVisibleTargets();
            var isTargetSighted = sensor.VisibleTargets.Count > 0;
            
            if (!isTargetSighted) return State.Failure;
            
            Child.Update();
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}
