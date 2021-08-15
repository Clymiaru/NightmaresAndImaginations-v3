using UnityEngine;

namespace TDS.AI
{
    public class ChaseTargetNode : ActionNode
    {
        private Mover mover;
        private Sensor sensor;
        
        public ChaseTargetNode(Mover mover, Sensor sensor) : base()
        {
            this.mover = mover;
            this.sensor = sensor;
        }
        
        protected override void OnStart()
        {
        }

        protected override State OnUpdate()
        {
            var visibleTargetObjects = sensor.VisibleTargets;

            GameObject target = null;
            foreach (var obj in visibleTargetObjects)
            {
                if (obj.CompareTag("Player"))
                {
                    target = obj;
                    break;
                }
            }
            
            if (target != null)
            {
                var vector = target.transform.position - 
                             sensor.gameObject.transform.position;
                
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
