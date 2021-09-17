using UnityEngine;

namespace TDS.AI
{
    public class DelayNode : DecoratorNode
    {
        private float elapsedTime;
        private readonly float duration;
        
        protected override void OnStart()
        {
            elapsedTime = 0.0f;
        }

        protected override State OnUpdate()
        {
            if (elapsedTime < duration)
            {
                return State.Success;
            }

            elapsedTime += Time.deltaTime;

            return State.Running;
        }

        protected override void OnStop()
        {
        }

        public DelayNode(Node child, Enemy owner, float duration) : base(child, owner)
        {
            this.duration = duration;
        }
    }

}
