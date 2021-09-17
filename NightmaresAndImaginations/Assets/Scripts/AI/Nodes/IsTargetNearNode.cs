
namespace TDS.AI
{
    public class IsTargetNearNode : DecoratorNode
    {
        private readonly Sensor sensor;
        
        public IsTargetNearNode(Node child, Enemy owner, Sensor sensor) : base(child, owner)
        {
            this.sensor = sensor;
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

