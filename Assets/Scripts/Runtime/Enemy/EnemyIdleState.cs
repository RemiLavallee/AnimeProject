namespace Runtime.Enemy
{
    public class EnemyIdleState : State
    {
        public override void Enter()
        {
            animator.Play("Idle");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Do()
        {
            base.Do();
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }
    }
}
