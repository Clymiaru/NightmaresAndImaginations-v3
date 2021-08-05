using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    /********
    Behavior:
    When the mask doesn't see the player:
    -> 
    
    When the mask sees the player:
    -> Move towards the player
    ********/
    public class MaskBehaviorTree : BehaviorTree
    {
        [SerializeField] private Sensor FarRangeSensor;
        [SerializeField] private Sensor PathSensor; 
        
        protected override RootNode CreateBehaviorTree()
        {
            var stats = GetComponent<StatsComponent>();
            var mover = GetComponent<Mover>();
            var sprite = GetComponent<SpriteRenderer>();

            var doNothingNode = new DoNothingNode();
            var chasePlayerNode = new ChaseTargetNode(mover, FarRangeSensor);
            
            var moveForwardNode = new MoveNode(mover);
            var turnAroundNode = new TurnAroundNode(transform);
            
           var isTargetInSightNode = new IsTargetInRangeNode(chasePlayerNode,
                                                             FarRangeSensor);
            
            var isPathBlockedNode = new IsPathBlockedNode(turnAroundNode, 
                                                          PathSensor);
            
            var selectNode = new SelectorNode(new List<Node>
                                              {
                                                  isTargetInSightNode, 
                                                  isPathBlockedNode, 
                                                  moveForwardNode
                                              });
            
            var repeatNode = new RepeatNode(0, selectNode);

            return new RootNode(repeatNode);
        }
    }

}
