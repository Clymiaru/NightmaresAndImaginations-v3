using UnityEngine;

namespace TDS.AI
{
    public class TestEnemyBehaviorTree : BehaviorTree
    {
        [SerializeField] private SpriteRenderer Sprite;
        [SerializeField] private Color FreeRoamSpriteColor;
        
        protected override RootNode CreateBehaviorTree()
        {
            var freeRoamSpriteVFX = new ChangeSpriteColorNode(Sprite, FreeRoamSpriteColor);

            return new RootNode(freeRoamSpriteVFX);
        }
    }
}

