using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyIdleState : State
    {
        [SerializeField] private AnimationClip anim;
        
        public override void Enter()
        {
            Animator.Play(anim.name);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Do()
        {
            base.Do();
        }

        protected override void FixedDo()
        {
            base.FixedDo();
        }
    }
}
