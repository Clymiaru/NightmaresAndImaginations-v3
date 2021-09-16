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

            // Depth 3
            var chasePlayerNode = new ChaseTargetNode(mover, FarRangeSensor);
            var turnAroundNode = new TurnAroundNode(transform);
            
            // Depth 2
            var isTargetInSightNode = new IsTargetInRangeNode(chasePlayerNode,
                                                              FarRangeSensor); 
            
            var isPathBlockedNode = new IsPathBlockedNode(turnAroundNode, 
                                                          PathSensorObj); 
            var moveForwardNode = new MoveNode(mover);
            
            // Depth 1
            var selectNode = new SelectorNode(new List<Node>
                                              {
                                                  isTargetInSightNode, 
                                                  isPathBlockedNode, 
                                                  moveForwardNode
                                              });
            
            // Depth 0
            var repeatNode = new RepeatNode(0, selectNode);

            return new RootNode(repeatNode);
        }

        private void InitializeRequirements()
        {
            stats = GetComponent<StatsComponent>();
            mover = GetComponent<Mover>();
            sprite = GetComponent<SpriteRenderer>();
        }
        
    }

}
