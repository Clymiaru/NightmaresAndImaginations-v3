using TDS.AI;
using UnityEngine;

namespace TDS
{
    public class MaskAttackNode : ActionNode
    {
        private MaskAttack maskAttack;

        public MaskAttackNode(MaskAttack maskAttack, Enemy owner) : base(owner)
        {
            this.maskAttack = maskAttack;
        }

        protected override void OnStart()
        {
            Owner.ChangeAnimationState("Attack");
            Owner.StartAttacking();
        }

        protected override State OnUpdate()
        {
            if (!Owner.IsAttacking)
            {
                Debug.Log("Attack Node");
                // Attack logic: turn on damage collision
                maskAttack.Attack();
                return State.Success;
            }
            
            return State.Running;
        }

        protected override void OnStop()
        {
            Owner.ChangeAnimationState("Idle");
        }
    }

}
