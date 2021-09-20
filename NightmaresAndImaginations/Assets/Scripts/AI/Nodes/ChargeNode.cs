using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class ChargeNode : DecoratorNode
    {
        private readonly float duration;
        private float elapsedTime;

        private const string ChargeState = "Charge";
        
        public ChargeNode(float chargeDuration, Node child, Enemy owner) : base(child, owner)
        {
            duration = chargeDuration;
        }

        protected override void OnStart()
        {
            elapsedTime = 0.0f;
            Owner.ChangeAnimationState(ChargeState);
        }

        protected override State OnUpdate()
        {
            if (elapsedTime <= duration)
            {
                elapsedTime += Time.deltaTime;
                return State.Running;
            }

            
            return Child.Update();
        }

        protected override void OnStop()
        {
        }
    }

}

