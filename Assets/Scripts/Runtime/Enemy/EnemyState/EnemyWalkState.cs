using UnityEngine;

namespace Runtime.Enemy.EnemyState
{
    public class EnemyWalkState : State
    {
        [SerializeField] private AnimationClip anim;
        
        public override void Enter()
        {
            Animator.Play(anim.name);
        }
    }
}