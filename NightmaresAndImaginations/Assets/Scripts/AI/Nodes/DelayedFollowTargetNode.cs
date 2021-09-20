using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class DelayedFollowTargetNode : ActionNode
    {
        private Mover mover;
        private TargetPositionChecker positionChecker;

        private float elapsedTime;
        private float duration = 1.0f;

        public DelayedFollowTargetNode(TargetPositionChecker positionChecker, Mover mover, Enemy owner) : base(owner)
        {
            this.positionChecker = positionChecker;
            this.mover = mover;
        }

        protected override void OnStart()
        {
            elapsedTime = 0;
            Owner.ChangeAnimationState("Idle");
        }

        protected override State OnUpdate()
        {
            if (elapsedTime >= duration)
            {
                return State.Success;
            }

            elapsedTime += Time.deltaTime;
            mover.Move(positionChecker.DirectionOffset);
            
            return State.Running;
        }

        protected override void OnStop()
        {
        }
    }
}
