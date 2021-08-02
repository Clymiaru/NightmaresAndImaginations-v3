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
            
            
            
            
            throw new System.NotImplementedException();
        }
    }

}
