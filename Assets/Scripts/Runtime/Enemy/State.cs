using UnityEngine;

namespace Runtime.Enemy
{
    public abstract class State : MonoBehaviour
    {
        public bool IsComplete { get; protected set; }
        private float _startTime;
        public float time => Time.time - _startTime;
        protected Animator Animator => stateMachineCore.animator;
        protected Rigidbody Rb => stateMachineCore.rb;
        protected StateMachineCore stateMachineCore;
        public StateMachine stateMachine;
        protected StateMachine parent;
        public State state => stateMachine.state;
    
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
            stateMachine = new StateMachine();
            this.stateMachineCore = core;
        }

        public void Initialize(StateMachine stateParent)
        {
            this.parent = stateParent;
            IsComplete = false;
            _startTime = Time.time;
        }
    }
}
