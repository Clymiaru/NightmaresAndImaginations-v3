using UnityEngine;

namespace TDS.AI
{
    public class ShootNode : ActionNode
    {
        private string attackAnimationClipName;
        private ShootProjectile attack;
        
        public ShootNode(string attackAnimClipName, ShootProjectile shootProjectile, Enemy owner) : base(owner)
        {
            attackAnimationClipName = attackAnimClipName;
            attack = shootProjectile;
        }

        protected override void OnStart()
        {
            Owner.StartAttacking();
            // SFX for shooting
            Owner.ChangeAnimationState(attackAnimationClipName);
        }

        protected override State OnUpdate()
        {
            if (!Owner.IsAttacking)
            {
                attack.Shoot();
                return State.Success;
            }

            return State.Running;
        }

        protected override void OnStop()
        {
        }
    }    
}

