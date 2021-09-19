using UnityEngine;

namespace TDS.AI
{
    public class DelayNode : DecoratorNode
    {
        private float elapsedTime;
        private readonly float duration;
        
        public DelayNode(float duration, Node child, Enemy owner) : base(child, owner)
        {
            this.duration = duration;
        }
        
        protected override void OnStart()
        {
            elapsedTime = 0.0f;
        }

        protected override State OnUpdate()
        {
            if (elapsedTime <= duration)
            {
                elapsedTime += Time.deltaTime;
                return State.Running;
            }
            
            return Child.Update();
        }

        protected override void OnStop()
        {
        }
    }
}
