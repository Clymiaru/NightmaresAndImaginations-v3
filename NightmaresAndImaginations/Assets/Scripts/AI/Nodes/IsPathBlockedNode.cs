
namespace TDS.AI
{
    public class IsPathBlockedNode : DecoratorNode
    {
        private readonly PathSensor sensor;
        
        public IsPathBlockedNode(PathSensor sensor, Node child, Enemy owner) : base(child, owner)
        {
            this.sensor = sensor;
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            var isPathBlocked = sensor.IsBlocked;
            return !isPathBlocked ? State.Failure : Child.Update();
        }

        protected override void OnStop()
        {
        }
    }
}

