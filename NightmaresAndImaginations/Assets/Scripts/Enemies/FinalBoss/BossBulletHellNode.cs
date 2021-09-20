using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class BossBulletHellNode : ActionNode
    {
        private float duration = 1.0f;
        private float elapsedTime;
        
        private BossBulletHellHandler bulletHellHandler;
        
        protected override void OnStart()
        {
            elapsedTime = 0.0f;
            Owner.ChangeAnimationState("Slash_Charging");
        }

        protected override State OnUpdate()
        {
            if (elapsedTime >= duration)
            {
                bulletHellHandler.Shoot();
                return State.Success;
            }

            elapsedTime += Time.deltaTime;
            return State.Running;
        }

        protected override void OnStop()
        {
        }

        public BossBulletHellNode(BossBulletHellHandler bulletHell, Enemy owner) : base(owner)
        {
            bulletHellHandler = bulletHell;
        }
    }
 
}
