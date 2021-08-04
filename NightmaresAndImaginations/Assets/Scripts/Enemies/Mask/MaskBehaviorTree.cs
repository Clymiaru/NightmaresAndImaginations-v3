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
        [SerializeField] private SightLineSensor FrontLineOfSight;
        [SerializeField] private SightLineSensor PathLineOfSight; 
        
        protected override RootNode CreateBehaviorTree()
        {
            var stats = GetComponent<StatsComponent>();
            var mover = GetComponent<Mover>();
            var sprite = GetComponent<SpriteRenderer>();
            
            var chasePlayerNode = new ChaseTargetNode(mover, FrontLineOfSight);
            var moveForwardNode = new MoveNode(mover, FrontLineOfSight);
            var turnAroundNode = new TurnAroundNode(new List<SightLineSensor>{PathLineOfSight, FrontLineOfSight}, 
                                                    sprite);
            
            var isTargetInSightNode = new IsTargetInRangeNode(chasePlayerNode,
                                                              FrontLineOfSight);
            
            var isPathBlockedNode = new IsPathBlockedNode(turnAroundNode, PathLineOfSight);
            
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
