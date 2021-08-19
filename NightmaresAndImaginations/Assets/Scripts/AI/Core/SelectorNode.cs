using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class SelectorNode : CompositeNode
    {
        public SelectorNode(List<Node> children) : base(children)
        {
        }
        
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            State state = State.Running;
            foreach (var node in Children)
            {
                Debug.Log($"Node: {node.GetType()}");
                switch (node.Update())
                {
                    case State.Failure:
                        break;
                    case State.Running:
                        state = State.Running;
                        return state;
                    case State.Success:
                        state = State.Success;
                        return state;
                }
            }
            
            state = State.Failure;
            return state;
        }

        protected override void OnStop()
        {
        }

        
    }
}
