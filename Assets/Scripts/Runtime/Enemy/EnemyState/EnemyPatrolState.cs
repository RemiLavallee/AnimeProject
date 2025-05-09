using UnityEngine;

namespace Runtime.Enemy.EnemyState
{
    public class EnemyPatrolState : State
    {
        public EnemyNavigateState navigate;
        public EnemyChaseState chase;
        public EnemyIdleState idle;
        public Transform point1;
        public Transform point2;
        public float duration;
        
        public override void Enter()
        {
            GoToNextDestination();
        }

        private void GoToNextDestination()
        {
            if (navigate.destination == point1.position)
            {
                navigate.destination = point2.position;
            }
            else
            {
                navigate.destination = point1.position;
            }
            
            Set(navigate, true);
        }
        
        public override void Do()
        {
            if (stateMachineCore is Enemy enemy && enemy.isAggroed)
            {
                Set(chase,true);
            }
            else
            {
                PatrolCondition();
            }
        }

        private void PatrolCondition()
        {
            if (stateMachine.state == navigate)
            {
                if (navigate.IsComplete)
                {
                    Set(idle, true);
                    Rb.linearVelocity = new Vector3(0, Rb.linearVelocity.y, 0);
                }
            }
            else
            {
                if (stateMachine.state.time > duration)
                {
                    GoToNextDestination();
                }
            }
        }
    }
}
