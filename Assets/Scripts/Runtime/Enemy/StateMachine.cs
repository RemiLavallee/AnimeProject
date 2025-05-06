namespace Runtime.Enemy
{
    public class StateMachine
    {
        public State State { get; private set; }

        public void Set(State newState, bool forceReset = false)
        {
            if (State != newState || forceReset)
            {
                State?.Exit();
                State = newState;
                State.Initialize();
                State.Enter();
            }
        }
    }
}
