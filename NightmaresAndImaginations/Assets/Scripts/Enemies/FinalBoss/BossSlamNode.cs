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
        private GameObject collider;
        
        public BossSlamNode(GameObject collider, Enemy owner) : base(owner)
        {
            this.collider = collider;
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
                collider.gameObject.SetActive(true);
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
    
    public class DisableObjectNode : ActionNode
    {
        private float elapsedTime;
        private float duration = 0.1f;
        private GameObject toDisable;
        
        public DisableObjectNode(GameObject toDisable, Enemy owner) : base(owner)
        {
            this.toDisable = toDisable;
        }

        protected override void OnStart()
        {
            elapsedTime = 0.0f;
        }

        protected override State OnUpdate()
        {
            if (elapsedTime >= duration)
            {
                toDisable.gameObject.SetActive(false);
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
