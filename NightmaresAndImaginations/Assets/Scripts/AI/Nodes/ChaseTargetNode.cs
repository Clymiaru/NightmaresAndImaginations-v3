using UnityEngine;

namespace TDS.AI
{
    public class ChaseTargetNode : ActionNode
    {
        private Mover mover;
        private GameObject target;
        
        public ChaseTargetNode(Mover mover) : base()
        {
            this.mover = mover;
        }
        
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            return State.Failure;
        }

        protected override void OnStop()
        {
        }
    }
}
