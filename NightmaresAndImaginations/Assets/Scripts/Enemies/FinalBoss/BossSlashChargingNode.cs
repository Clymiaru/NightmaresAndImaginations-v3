using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class BossSlashChargingNode : ActionNode
    {
        private float duration = 1.0f;
        private float elapsedTime;

        protected override void OnStart()
        {
            elapsedTime = 0.0f;
            Owner.ChangeAnimationState("Slash_Charging");
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

        public BossSlashChargingNode(Enemy owner) : base(owner)
        {
        }
    }
}
