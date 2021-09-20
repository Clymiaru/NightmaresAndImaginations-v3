using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class BossSlashNode : ActionNode
    {
        private float elapsedTime;
        private float duration = 1.0f;
        private GameObject collider;
        public BossSlashNode(GameObject collider, Enemy owner) : base(owner)
        {
            this.collider = collider;
        }

        protected override void OnStart()
        {
            elapsedTime = 0.0f;
            Owner.ChangeAnimationState("Slash");
        }

        protected override State OnUpdate()
        {
            if (elapsedTime >= duration)
            {
                Owner.StopAttacking();
                Debug.Log("Hello");
                collider.SetActive(true);
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
