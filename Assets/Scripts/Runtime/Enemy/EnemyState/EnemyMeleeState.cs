using UnityEngine;

namespace Runtime.Enemy.EnemyState
{
    public class EnemyMeleeState : State
    {
        public EnemyNavigateState navigate;
        public EnemyAttackState attack;
        public GameObject player;
        public float meleeRange = 2f;
        
        public override void Do()
        {
            var core = stateMachineCore as Enemy;
            if (core == null) return;

            float dist = Vector3.Distance(core.transform.position, player.transform.position);

            if (dist > meleeRange)
            {
                if (!attack.isAttacking)
                {
                    navigate.destination = player.transform.position;
                    Set(navigate, true);
                }
            }
            else
            {
                Set(attack, true);
            }
        }
    }
}
