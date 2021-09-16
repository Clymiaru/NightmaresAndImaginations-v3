using UnityEngine;
using UnityEngine.Assertions;

namespace TDS.AI
{
    public class RepeatNode : DecoratorNode
    {
        [Tooltip("Repeats N times. If 0, it repeats infinitely.")]
        private readonly int repeatCount;

        private int currentCount;

        public RepeatNode(int repeatCount, Node child, Enemy owner) : base(child, owner)
        {
            this.repeatCount = repeatCount;
            Assert.IsTrue(this.repeatCount >= 0, "this.repeatCount >= 0. Must be either 0 or a positive number!");
            
            currentCount = 0;
        }

        protected override void OnStart()
        {
            currentCount = 0;
        }

        protected override State OnUpdate()
        {
            if (repeatCount == 0)
            {
                Child.Update();
                return State.Running;   
            }
            
            if (currentCount >= repeatCount)
            {
                return State.Success;
            }
            
            currentCount++;
            Child.Update();
            return State.Running;   
        }

        protected override void OnStop()
        {
        }
    }
}
