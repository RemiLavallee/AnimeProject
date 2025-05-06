using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyPatrolState : State
    {
        [SerializeField] private AnimationClip anim;

        public State navigate;
        public EnemyIdleState idle;
        public Transform point1;
        public Transform point2;
        
        public override void Enter()
        {
            Animator.Play(anim.name);
            GoToNextDestination();
        }

        private void GoToNextDestination()
        {
            var randomSpot = Random.Range(point1.position.x, point2.position.x);
            // navigate.destination = new Vector2(randomSpot, stateMachineCore.transform.position.y);
            Set(navigate, true);
        }

        public override void Exit() { }


        public override void Do()
        {
            if (stateMachine.State == navigate)
            {
                Set(idle, true);
                Rb.linearVelocity = new Vector3(0, Rb.linearVelocity.y, Rb.linearVelocity.z);
            }
            else
            {
                if (stateMachine.State.time > 1)
                {
                    GoToNextDestination();
                }
            }
        }

        protected override void FixedDo() { }

    }
}
