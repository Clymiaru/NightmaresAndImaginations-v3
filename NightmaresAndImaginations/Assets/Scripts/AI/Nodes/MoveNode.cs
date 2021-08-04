using TDS.AI;
using UnityEngine;

namespace TDS
{
    public class MoveNode : ActionNode
    {
        private readonly Mover mover;
        private readonly SightLineSensor sightSensor;

        public MoveNode(Mover moveComponent, SightLineSensor sightSensor)
        {
            mover = moveComponent;
            this.sightSensor = sightSensor;
        }
        
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            mover.SetSpeedModifier(1.0f);
            mover.Move(sightSensor.GetDirection());
            return State.Success;
        }

        protected override void OnStop()
        {
            mover.Stop();
        }
    }
}
