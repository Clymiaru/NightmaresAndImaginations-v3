namespace TDS.AI
{
    public class IsPathBlockedNode : DecoratorNode
    {
        private SightLineSensor pathSightSensor;
        public IsPathBlockedNode(Node child, SightLineSensor sensor) : base(child)
        {
            pathSightSensor = sensor;
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            var isPathBlocked = pathSightSensor.IsTargetWithinSight();
            
            if (!isPathBlocked) return State.Failure;
            
            Child.Update();
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}

