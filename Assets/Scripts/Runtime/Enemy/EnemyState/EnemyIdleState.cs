using UnityEngine;

namespace Runtime.Enemy.EnemyState
{
    public class EnemyIdleState : State
    {
        public AnimationClip anim;
        
        public override void Enter()
        {
            Animator.Play(anim.name);
        }
    }
}
