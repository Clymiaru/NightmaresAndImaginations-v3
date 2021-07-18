namespace TDS.AI
{
    public class ChaseTargetNode : ActionNode
    {
        public ChaseTargetNode() : base()
        {
            
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
