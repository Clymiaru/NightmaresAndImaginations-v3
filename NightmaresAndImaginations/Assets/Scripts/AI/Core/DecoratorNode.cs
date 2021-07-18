using UnityEngine;

namespace TDS.AI
{
    public abstract class DecoratorNode : Node
    {
        protected readonly Node Child;

        public DecoratorNode(Node child)
        {
            Child = child;
        }
    }
}
