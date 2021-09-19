using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class BossSlashArmUpNode : ActionNode
    {
        private float elapsedTime;
        private float duration = 0.3f;
        
        public BossSlashArmUpNode(Enemy owner) : base(owner)
        {
        }

        protected override void OnStart()
        {
            elapsedTime = 0.0f;
            Owner.ChangeAnimationState("Slash_ArmsUp");
        }

        protected override State OnUpdate()
        {
            if (elapsedTime >= duration)
            {
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
