using UnityEngine;

namespace Runtime.Enemy
{
    public class StateMachineCore : MonoBehaviour
    {
        public Animator Animator { get; private set; }
        public Rigidbody Rb { get; private set; }
        protected StateMachine StateMachine;

        public void SetupInstances()
        {
            StateMachine = new StateMachine();

            var allChildStates = GetComponentsInChildren<State>();

            foreach (var childState in allChildStates)
            {
                childState.SetCore(this);
            }
        }
    }
}
