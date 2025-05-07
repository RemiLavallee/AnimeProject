using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyChaseState : State
    {
        public EnemyNavigateState navigate;
        public EnemyPatrolState patrol;
        public GameObject player;
        
        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Do()
        {
            
            navigate.destination = player.transform.position;
            Set(navigate, true);
        }

        protected override void FixedDo()
        {
            base.FixedDo();
        }
        
    }
}
