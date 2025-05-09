using UnityEngine;

namespace Runtime.Enemy.EnemyState
{
    public class StateMachineCore : MonoBehaviour
    {
        public Animator animator;
        public Rigidbody rb;
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
