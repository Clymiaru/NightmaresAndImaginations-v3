using TDS.AI;

namespace TDS
{
    public class IdleNode : ActionNode
    {
        public IdleNode(Enemy owner) : base(owner)
        {
            
        }
        
        protected override void OnStart()
        {
            // Play Idle Animation
        }

        protected override State OnUpdate()
        {
            return State.Success;
        }

        protected override void OnStop()
        {
            
        }
    }
}
