using System.Collections;
using System.Collections.Generic;
using TDS.AI;
using UnityEngine;

namespace TDS.AI
{
    public class RandomActionSelectionNode : CompositeNode
    {
        private int index;
        
        public RandomActionSelectionNode(List<Node> children, Enemy owner) : base(children, owner)
        {
            
        }
        
        protected override void OnStart()
        {
            index = Random.Range(0, Children.Count );
        }

        protected override State OnUpdate()
        {
            State state = State.Running;
            switch (Children[index].Update())
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
            
            state = State.Failure;
            return state;
        }

        protected override void OnStop()
        {
            index = Random.Range(0, Children.Count );
        }

        
    }

}
