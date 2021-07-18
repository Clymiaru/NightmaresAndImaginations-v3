using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class SelectorNode : CompositeNode
    {
        private int currentNodeIndex;
        
        public SelectorNode(List<Node> children) : base(children)
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
                    currentNodeIndex++;
                    break;
                case State.Success:
                    return State.Success;
            }

            return currentNodeIndex == Children.Count ? State.Failure : State.Running;;
        }
    
        protected override void OnStop()
        {
        }
    }
}
