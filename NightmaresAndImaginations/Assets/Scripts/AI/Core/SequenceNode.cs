using System.Collections.Generic;

namespace TDS.AI
{
    public class SequenceNode : CompositeNode
    {
        private int currentNodeIndex;
        
        public SequenceNode(List<Node> children) : base(children)
        {
            currentNodeIndex = 0;
        }
       
        protected override void OnStart()
        {
            currentNodeIndex = 0;
        }

        protected override State OnUpdate()
        {
            var child = Children[currentNodeIndex];

            switch (child.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Failure:
                    return State.Failure;
                case State.Success:
                    currentNodeIndex++;
                    break;
            }

            return currentNodeIndex == Children.Count ? State.Success : State.Running;
        }

        protected override void OnStop()
        {
        }
    }
}
