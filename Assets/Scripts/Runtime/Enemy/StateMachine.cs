namespace Runtime.Enemy
{
    public class StateMachine
    {
        public State state;

        public void Set(State newState, bool forceReset = false)
        {
            if (state != newState || forceReset)
            {
                state?.Exit();
                state = newState;
                state.Initialize(state.stateMachine);
                state.Enter();
            }
        }
    }
}
