using System;
using TDS.AI;

namespace TDS
{
    public class IdleNode : ActionNode
    {
        private const string IdleState = "Idle";
        public IdleNode(Enemy owner) : base(owner)
        {
            
        }
        
        protected override void OnStart()
        {
            Owner.ChangeAnimationState(IdleState);
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
