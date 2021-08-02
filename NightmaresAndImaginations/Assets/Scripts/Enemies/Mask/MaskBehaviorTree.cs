using System.Collections;
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
        protected override RootNode CreateBehaviorTree()
        {
            // Check if player is sighted/in-range
            
            // If yes:
            // Chase player
            
            // If not:
            // Patrol
            
            
            // Idle State

            var doNothingNode = new DoNothingNode();
            var moveNode = new MoveNode(GetComponent<Mover>());
            var isTargetInSightNode = new IsTargetInRangeNode(moveNode, GetComponent<SightLineSensor>());

            var repeatNode = new RepeatNode(0, isTargetInSightNode);


            return new RootNode(repeatNode);
        }
    }

}
