using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public abstract class CompositeNode : Node
    {
        protected readonly List<Node> Children;

        public CompositeNode(List<Node> children, Enemy owner) : base(owner)
        {
            Children = children;
        }
    }
}

