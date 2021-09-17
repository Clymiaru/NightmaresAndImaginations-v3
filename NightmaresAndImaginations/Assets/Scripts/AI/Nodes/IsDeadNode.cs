using UnityEditor;
using UnityEngine;

namespace TDS.AI
{
    public class IsDeadNode : DecoratorNode
    {
        private StatsComponent stats;
        private string deathAnimationClipName;
        
        public IsDeadNode(Node child, Enemy owner, string deathAnimClipName) : base(child, owner)
        {
            stats = Owner.GetComponent<StatsComponent>();
            deathAnimationClipName = deathAnimClipName;
        }

        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            if (!stats.IsDead)
            {
                return State.Failure;
            }
            
            Owner.ChangeAnimationState(deathAnimationClipName);
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}
