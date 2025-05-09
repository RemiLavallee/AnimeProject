using Runtime.Enemy.EnemyState;
using UnityEngine;

namespace Runtime.Enemy.EnemyState
{
    public class EnemyChaseState : State
    {
        public EnemyNavigateState navigate;
        public EnemyMeleeState melee;
        public GameObject player;

        public override void Enter()
        {
            navigate.destination = player.transform.position;
            Set(navigate, true);
        }

        public override void Do()
        {
            navigate.destination = player.transform.position;
            Set(navigate, true);
            
            if(stateMachineCore is Enemy enemy && enemy.isMelee) Set(melee, true);
        }
    }
}
