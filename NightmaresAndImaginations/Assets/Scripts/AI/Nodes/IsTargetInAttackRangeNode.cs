using UnityEngine;

namespace TDS.AI
{
    public class IsTargetInAttackRangeNode : DecoratorNode
    {
        private AttackRangeSensor attackRangeSensor;
        private Mover mover;
        public IsTargetInAttackRangeNode(AttackRangeSensor sensor,
                                         Mover mover,
                                         Node child, 
                                         Enemy owner) : base(child, owner)
        {
            this.mover = mover;
            attackRangeSensor = sensor;
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            if (!attackRangeSensor.InRange)
            {
                return State.Failure;
            }

            mover.Stop();
            return Child.Update();
        }

        protected override void OnStop()
        {
        }
    }
}
