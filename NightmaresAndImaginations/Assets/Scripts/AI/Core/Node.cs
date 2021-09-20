
using UnityEngine;

namespace TDS.AI
{
    public abstract class Node
    {
        public State State { get; protected set; } = State.Running;
        private bool hasStarted = false;
        protected readonly Enemy Owner;

        protected Node(Enemy owner)
        {
            Owner = owner;
        }

        public State Update()
        {
            if (!hasStarted)
            {
                OnStart();
                hasStarted = true;
            }

            State = OnUpdate();

            if (State != State.Success && State != State.Failure)
            {
                return State;
            }
            
            OnStop();
            hasStarted = false;

            return State;
        }
        
        protected abstract void OnStart();
        protected abstract State OnUpdate();
        protected abstract void OnStop();
    }

    public enum State
    {
        Failure = -1,
        Running = 0, 
        Success = 1
    }
}

