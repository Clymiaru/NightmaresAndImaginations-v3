using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class TestEnemyBehaviorTree : BehaviorTree
    {
        [SerializeField] private SpriteRenderer Sprite;
        [SerializeField] private Color FreeRoamSpriteColor;
        [SerializeField] private Color TargetInRangeSpriteColor;
        
        protected override RootNode CreateBehaviorTree()
        {
            var target = GameObject.FindWithTag("Player");
            
            var freeRoamSpriteVFX = new ChangeSpriteColorNode(Sprite, FreeRoamSpriteColor);
            
            var targetInRangeSpriteColor = new ChangeSpriteColorNode(Sprite, TargetInRangeSpriteColor);

            // var isTargetInRange = new IsTargetInRangeNode(targetInRangeSpriteColor, gameObject, target, 5.0f);

            // var sequence = new SelectorNode(new List<Node>{isTargetInRange, freeRoamSpriteVFX});
            
            var repeatNode = new RepeatNode(0, new DoNothingNode());
            
            return new RootNode(repeatNode);
        }
    }
}

