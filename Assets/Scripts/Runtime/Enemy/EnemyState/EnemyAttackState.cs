using UnityEngine;

namespace Runtime.Enemy.EnemyState
{
    public class EnemyAttackState : State
    {
        public AnimationClip anim;
        public float attackCooldown = 2f;
        public EnemyMeleeState melee;
        public bool isAttacking;
        private float timer;

        public override void Enter()
        {
            isAttacking = true;
            timer = 0f;
            
            Rb.linearVelocity = Vector3.zero;
            Animator.Play(anim.name);
        }

        public override void Do()
        {
            if (isAttacking)
            {
                timer += Time.deltaTime;
                
                if (timer >= anim.length)
                {
                    isAttacking = false;
                    timer = attackCooldown; 
                }
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0f)
                {
                    Set(melee, true);
                }
            }
        }
    }
}
