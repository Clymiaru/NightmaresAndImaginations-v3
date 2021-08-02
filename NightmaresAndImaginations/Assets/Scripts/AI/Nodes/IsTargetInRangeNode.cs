using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class IsTargetInRangeNode : DecoratorNode
    {
        private readonly SightLineSensor sightSensor;
        
        public IsTargetInRangeNode(Node child, SightLineSensor sightSensor) : base(child)
        {
            this.sightSensor = sightSensor;
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            var isTargetSighted = sightSensor.IsTargetWithinSight();

            if (!isTargetSighted) return State.Failure;
            
            Child.Update();
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}
