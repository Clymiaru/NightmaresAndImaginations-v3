using System;
using UnityEngine;

namespace TDS.AI
{
    public abstract class BehaviorTree : MonoBehaviour
    {
        private RootNode rootNode;

        protected abstract RootNode CreateBehaviorTree();

        private void Start()
        {
            rootNode = CreateBehaviorTree();
        }

        private void Update()
        {
            if (rootNode.State == State.Running)
            {
                rootNode.Update();
            }
        }
    }
}
