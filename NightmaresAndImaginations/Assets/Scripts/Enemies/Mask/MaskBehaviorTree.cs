using System.Collections.Generic;

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
            var isTargetInSightNode = new IsTargetInRangeNode(doNothingNode, GetComponent<SightLineSensor>());

            // var chasePlayerNode = new ChaseTargetNode();

            var selectNode = new SelectorNode(new List<Node> {isTargetInSightNode, doNothingNode});
            var repeatNode = new RepeatNode(0, selectNode);

            return new RootNode(repeatNode);
        }
    }

}
