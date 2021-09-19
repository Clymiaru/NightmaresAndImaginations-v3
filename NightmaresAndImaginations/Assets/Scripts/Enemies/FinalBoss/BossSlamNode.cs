using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace TDS.AI
{
    public class BossSlamNode : ActionNode
    {
        private float elapsedTime;
        private float duration = 1.0f;
        
        public BossSlamNode(Enemy owner) : base(owner)
        {
            
        }

        protected override void OnStart()
        {
            elapsedTime = 0.0f;
            Owner.ChangeAnimationState("Slam");
        }

        protected override State OnUpdate()
        {
            if (elapsedTime >= duration)
            {
                Owner.StopAttacking();
                Owner.ChangeAnimationState("Idle");
                return State.Success;
            }

            elapsedTime += Time.deltaTime;
            return State.Running;
        }

        protected override void OnStop()
        {
        }
    }

}
