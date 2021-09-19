using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class MaskBehaviorTree : BehaviorTree
    {
        [SerializeField] private Sensor FarRangeSensor;
        [SerializeField] private PathSensor PathSensorObj; 
        
        // Requirements
        private StatsComponent stats;
        private Mover mover;
        private SpriteRenderer sprite;
        
        protected override RootNode CreateBehaviorTree()
        {
            InitializeRequirements();

            // // Depth 3
            // var chasePlayerNode = new ChaseTargetNode(owner, mover, FarRangeSensor);
            // var turnAroundNode = new TurnAroundNode(owner, transform);
            //
            // // Depth 2
            // var isTargetInSightNode = new IsTargetInRangeNode(chasePlayerNode,
            //                                                   owner,
            //                                                   FarRangeSensor); 
            //
            // // var isTargetNearNode
            // // var attackNode
            //
            // var isPathBlockedNode = new IsPathBlockedNode(turnAroundNode,
            //                                               owner,
            //                                               PathSensorObj); 
            // var moveForwardNode = new MoveNode(mover, owner);
            //
            
            // // Depth 4
            // var doNothingNode = new DoNothingNode(owner);
            //
            // // Depth 3
            // var destroyDelayNode = new DelayNode(doNothingNode, owner, 0.1f);
            // var attackNode = new AttackNode(owner, "MaskAttackAnim");
            //
            // // Depth 2
            // var isDeadNode = new IsDeadNode(destroyDelayNode, owner, "MaskDeathAnim");
            // var isTargetInAttackRange = new IsTargetInAttackRangeNode(attackNode, owner);
            //
            // // Depth 1
            // var selectNode = new SelectorNode(new List<Node>
            //                                   {
            //                                       isDeadNode
            //                                   },
            //                                   owner);
            //
            // // Depth 0
            // var repeatNode = new RepeatNode(selectNode, owner, 0);
            //

            return new RootNode(null, null);
        }

        private void InitializeRequirements()
        {
            stats = GetComponent<StatsComponent>();
            mover = GetComponent<Mover>();
            sprite = GetComponent<SpriteRenderer>();
        }
        
    }

}
