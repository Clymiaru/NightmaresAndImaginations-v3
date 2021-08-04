using UnityEngine;

namespace TDS.AI
{
    public class ChaseTargetNode : ActionNode
    {
        private Mover mover;
        private SightLineSensor sightTargetSensor;
        
        public ChaseTargetNode(Mover mover, SightLineSensor sightSensor) : base()
        {
            this.mover = mover;
            sightTargetSensor = sightSensor;
        }
        
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            var targetObj = sightTargetSensor.RetriveSightedTarget(); 
            
            if (targetObj != null)
            {
                var vector = targetObj.transform.position - 
                             sightTargetSensor.gameObject.transform.position;
                
                mover.SetSpeedModifier(3.0f);
                mover.Move(vector.normalized);
            }
            return State.Success;
        }

        protected override void OnStop()
        {
        }
    }
}
