namespace TDS.AI
{
    public class DoNothingNode : ActionNode
    {
        public DoNothingNode(Enemy owner) : base(owner)
        {
        }

        protected override void OnStart()
        {
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
