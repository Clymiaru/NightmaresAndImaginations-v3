using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class BossSlamChargingNode : ActionNode
    {
        
        private float elapsedTime;
        private float duration = 1.0f;
        
        public BossSlamChargingNode(Enemy owner) : base(owner)
        {
            
        }

        protected override void OnStart()
        {
            elapsedTime = 0.0f;
            Owner.ChangeAnimationState("Slam_Charging");
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

