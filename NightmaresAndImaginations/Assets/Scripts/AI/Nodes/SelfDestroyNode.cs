using UnityEngine;

namespace TDS.AI
{
    public class SelfDestroyNode : ActionNode
    {
        public SelfDestroyNode(Enemy owner) : base(owner)
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
            GameObject.Destroy(Owner);
        }
    }
}
