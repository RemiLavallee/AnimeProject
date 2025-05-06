using UnityEngine;

namespace Runtime.Enemy
{
    public abstract class State : MonoBehaviour
    {
        public bool IsComplete { get; protected set; }
        private float _startTime;
        public float time => Time.time - _startTime;
        protected Animator Animator => stateMachineCore.Animator;
        protected Rigidbody Rb => stateMachineCore.Rb;
        public StateMachineCore stateMachineCore;
        public StateMachine stateMachine;
        public State parent;
        public State state => stateMachine.State;
    
        public virtual void Enter() {}
        public virtual void Exit() {}
        public virtual void Do() {}
        protected virtual void FixedDo() {}

        public void DoBranch()
        {
            Do();
            state?.DoBranch();
        }
        
        public void FixedDoBranch()
        {
            FixedDo();
            state?.FixedDoBranch();
        }

        protected void Set(State newState, bool forceReset = false)
        {
            stateMachine.Set(newState, forceReset);
        }
        
        public void SetCore(StateMachineCore core)
        {
            this.stateMachineCore = core;
        }

        public void Initialize()
        {
            IsComplete = false;
            _startTime = Time.time;
        }
    }
}
