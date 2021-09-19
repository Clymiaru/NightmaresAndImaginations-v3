using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class DelayedFollowTargetNode : ActionNode
    {
        private Vector2 moveDirection;
        private GameObject target;
        private Mover mover;

        private float elapsedTime;
        private float duration = 1.0f;

        public DelayedFollowTargetNode(GameObject target, Mover mover, Enemy owner) : base(owner)
        {
            this.target = target;
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
            mover.Move((target.transform.position - Owner.transform.position).normalized);
            
            return State.Running;
        }

        protected override void OnStop()
        {
        }
    }
}
