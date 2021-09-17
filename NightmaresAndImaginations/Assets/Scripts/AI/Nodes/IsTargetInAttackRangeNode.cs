using UnityEngine;

namespace TDS.AI
{
    public class IsTargetInAttackRangeNode : DecoratorNode
    {
        public IsTargetInAttackRangeNode(Node child, Enemy owner) : base(child, owner)
        {
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}
