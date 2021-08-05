using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class TurnAroundNode : ActionNode
    {
        private readonly Transform transform;
        
        public TurnAroundNode(Transform transform)
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
