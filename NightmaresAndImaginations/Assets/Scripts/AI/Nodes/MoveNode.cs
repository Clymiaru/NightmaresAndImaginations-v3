using TDS.AI;
using UnityEngine;

namespace TDS
{
    public class MoveNode : ActionNode
    {
        private readonly Mover mover;

        public MoveNode(Mover moveComponent)
        {
            mover = moveComponent;

        }
        
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            mover.SetSpeedModifier(1.0f);
            var direction = new Vector2(mover.transform.localScale.x,
                                        0.0f);
            
            mover.Move(direction);
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}
