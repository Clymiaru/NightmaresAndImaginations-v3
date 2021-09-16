using UnityEngine;

namespace TDS.AI
{
    public class RootNode : Node
    {
        private readonly Node child;

        public RootNode(Node child, Enemy owner) : base(owner)
        {
            this.child = child;
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            return child.Update();
        }

        protected override void OnStop()
        {
        }
    }

}

