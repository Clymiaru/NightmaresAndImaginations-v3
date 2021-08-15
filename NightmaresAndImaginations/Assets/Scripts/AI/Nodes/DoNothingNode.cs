using TDS.AI;

namespace TDS
{
    public class DoNothingNode : ActionNode
    {
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
