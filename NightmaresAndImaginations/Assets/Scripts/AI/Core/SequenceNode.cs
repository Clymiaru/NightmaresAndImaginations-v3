using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class SequenceNode : CompositeNode
    {
        private int currentNodeIndex;
        
        public SequenceNode(List<Node> children, Enemy owner) : base(children, owner)
        {
            currentNodeIndex = 0;
        }
        // public override NodeState Evaluate()
        // {
        //     if (currentNodeIndex >= nodes.Count)
        //     {
        //         return NodeState.Success;
        //     }
        //     
        //     state = nodes[currentNodeIndex].Evaluate();
        //
        //     switch (state)
        //     {
        //         case NodeState.Failure:
        //             currentNodeIndex = 0;
        //             return NodeState.Failure;
        //         case NodeState.Running:
        //             return NodeState.Running;
        //         case NodeState.Success:
        //             currentNodeIndex++;
        //             break;
        //     }
        //     
        //     if (currentNodeIndex < nodes.Count)
        //     {
        //         return NodeState.Running;
        //     }
        //     
        //     currentNodeIndex = 0;
        //     return NodeState.Success;
        // }
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
                    return State.Success;
                case State.Success:
                    currentNodeIndex++;
                    break;
            }

            return currentNodeIndex == Children.Count ? State.Success : State.Running;
        }

        protected override void OnStop()
        {
            throw new NotImplementedException();
        }
    }
}
