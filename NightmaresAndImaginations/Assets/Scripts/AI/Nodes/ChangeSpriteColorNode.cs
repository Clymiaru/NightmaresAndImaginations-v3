using UnityEngine;

namespace TDS.AI
{
    public class ChangeSpriteColorNode : ActionNode
    {
        private readonly SpriteRenderer sprite;
        private readonly Color changeToColor;

        public ChangeSpriteColorNode(SpriteRenderer sprite, Color changeToColor)
        {
            this.sprite = sprite;
            this.changeToColor = changeToColor;
        }
        
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            sprite.color = changeToColor;
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}

