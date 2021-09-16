using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    [RequireComponent(typeof(Mask))]
    public class MaskBehaviorTree : BehaviorTree
    {
        [SerializeField] private Sensor FarRangeSensor;
        [SerializeField] private PathSensor PathSensorObj; 
        
        // Requirements
        private Mask owner;
        private StatsComponent stats;
        private Mover mover;
        private SpriteRenderer sprite;
        
        protected override RootNode CreateBehaviorTree()
        {
            InitializeRequirements();

            // Depth 3
            var chasePlayerNode = new ChaseTargetNode(owner, mover, FarRangeSensor);
            var turnAroundNode = new TurnAroundNode(owner, transform);
            
            // Depth 2
            var isTargetInSightNode = new IsTargetInRangeNode(chasePlayerNode,
                                                              owner,
                                                              FarRangeSensor); 
            
            var isPathBlockedNode = new IsPathBlockedNode(turnAroundNode,
                                                          owner,
                                                          PathSensorObj); 
            var moveForwardNode = new MoveNode(mover, owner);
            
            // Depth 1
            var selectNode = new SelectorNode(new List<Node>
                                              {
                                                  isTargetInSightNode, 
                                                  isPathBlockedNode, 
                                                  moveForwardNode
                                              },
                                              owner);
            
            // Depth 0
            var repeatNode = new RepeatNode(0, selectNode, owner);

            return new RootNode(repeatNode, owner);
        }

        private void InitializeRequirements()
        {
            stats = GetComponent<StatsComponent>();
            mover = GetComponent<Mover>();
            sprite = GetComponent<SpriteRenderer>();
            owner = GetComponent<Mask>();
        }
        
    }

}
