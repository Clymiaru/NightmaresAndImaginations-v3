using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class MaskBehaviorTree : BehaviorTree
    {
        [SerializeField] private PathSensor PathSensor;
        [SerializeField] private Sensor FarRangeSensor;
        [SerializeField] private AttackRangeSensor AttackRangeSensor;
        [SerializeField] private MaskAttack MaskAttack;
        private StatsComponent stats;
        private Mover mover;
        private SpriteRenderer sprite;
        private Enemy owner;
        
        protected override RootNode CreateBehaviorTree()
        {
            InitializeRequirements();

            // Depth 3
            var chasePlayerNode = new ChaseTargetNode(owner, mover, FarRangeSensor);
            
            // // Depth 2
            
            
            // // var isTargetNearNode
            // // var attackNode
            //
            // var isPathBlockedNode = new IsPathBlockedNode(turnAroundNode,
            //                                               owner,
            //                                               PathSensorObj); 
            //
            
            // Depth 4
            var doNothingNode = new DoNothingNode(owner);
            
            var attackNode = new MaskAttackNode(MaskAttack, owner);
            
            // Depth 3
            var destroyDelayNode = new DelayNode(0.1f, doNothingNode, owner);
            
            var turnAroundNode = new TurnAroundNode(owner, transform);

            var attackDelayNode = new DelayNode(0.8f, attackNode, owner);

            
            // Depth 2
            var isDeadNode = new IsDeadNode(destroyDelayNode, owner, "Death");

            var isPathBlocked = new IsPathBlockedNode(PathSensor, turnAroundNode, owner);
            
            var isTargetInAttackRange = new IsTargetInAttackRangeNode(AttackRangeSensor,
                                                                      mover,
                                                                      attackDelayNode, 
                                                                      owner);
            
            var isTargetInSightNode = new IsTargetInRangeNode(chasePlayerNode,
                                                              owner,
                                                              FarRangeSensor); 
            
            
            var moveForwardNode = new MoveNode(mover, owner);

            var idleNode = new IdleNode(owner);
            
            // Depth 1
            var selectNode = new SelectorNode(new List<Node>
                                              {
                                                  isDeadNode,
                                                  isPathBlocked,
                                                  isTargetInAttackRange,
                                                  isTargetInSightNode,
                                                  moveForwardNode,
                                                  idleNode
                                              },
                                              owner);
            
            // Depth 0
            var repeatNode = new RepeatNode(selectNode, owner, 0);
            
            return new RootNode(repeatNode, owner);
        }

        private void InitializeRequirements()
        {
            stats = GetComponent<StatsComponent>();
            mover = GetComponent<Mover>();
            sprite = GetComponent<SpriteRenderer>();
            owner = GetComponent<Enemy>();
        }
        
    }

}
