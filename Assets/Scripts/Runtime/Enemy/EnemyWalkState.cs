using UnityEngine;

namespace Runtime.Enemy
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