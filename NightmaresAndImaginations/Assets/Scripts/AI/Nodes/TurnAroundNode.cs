using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class TurnAroundNode : ActionNode
    {
        private readonly List<SightLineSensor> sensors;
        private readonly SpriteRenderer sprite;
        public TurnAroundNode(List<SightLineSensor> sightSensors, SpriteRenderer sprite)
        {
            sensors = sightSensors;
            this.sprite = sprite;
        }
        
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            foreach (var sensor in sensors)
            {
                sensor.FlipDirection();
            }
            sprite.flipX = !sprite.flipX;
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}
