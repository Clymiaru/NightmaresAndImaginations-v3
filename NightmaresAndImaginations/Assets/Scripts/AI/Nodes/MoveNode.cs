using System.Collections;
using System.Collections.Generic;
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
            mover.Move(new Vector2(1.0f, 0.0f));
            return State.Success;
        }

        protected override void OnStop()
        {
            mover.Stop();
        }
    }
}
