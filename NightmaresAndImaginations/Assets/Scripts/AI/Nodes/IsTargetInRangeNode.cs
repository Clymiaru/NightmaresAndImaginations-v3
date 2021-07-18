using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class IsTargetInRangeNode : DecoratorNode
    {
        private GameObject player;
        private GameObject target;
        private float sightRange;
        
        public IsTargetInRangeNode(Node child, GameObject player, GameObject target, float range) : base(child)
        {
            this.player = player;
            this.target = target;
            sightRange = range;

        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            var targetDistance = Vector2.Distance(player.transform.position, 
                                                      target.transform.position);
            if (targetDistance < sightRange)
            {
                Child.Update();
                return State.Success;
            }

            return State.Failure;
        }

        protected override void OnStop()
        {
        }
    }
}
