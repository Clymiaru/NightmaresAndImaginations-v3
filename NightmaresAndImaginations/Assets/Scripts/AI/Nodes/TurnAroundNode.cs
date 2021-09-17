using UnityEngine;

namespace TDS.AI
{
    public class TurnAroundNode : ActionNode
    {
        private readonly Transform transform;
        
        public TurnAroundNode(Enemy owner, Transform transform) : base(owner)
        {
            this.transform = transform;
        }
        
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            var currentScale = transform.localScale;
            transform.localScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}
