namespace TDS.AI
{
    public class AttackNode : ActionNode
    {
        private string attackAnimationClipName;
        
        public AttackNode(Enemy owner, string attackAnimClipName) : base(owner)
        {
            attackAnimationClipName = attackAnimClipName;
        }

        protected override void OnStart()
        {
            Owner.IsFinishedAttacking = false;
        }

        protected override State OnUpdate()
        {
            // Deal damage function
            if (Owner.IsFinishedAttacking)
            {
                return State.Success;
            }
            
            Owner.ChangeAnimationState(attackAnimationClipName);
            return State.Running;
        }

        protected override void OnStop()
        {
        }
    }    
}

