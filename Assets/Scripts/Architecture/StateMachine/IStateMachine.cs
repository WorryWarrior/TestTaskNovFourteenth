public interface IStateMachine : IService
{
    public void Enter<TState>() where TState : class, IState;
    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>;
    public void RegisterState<TState>(TState state) where TState : IExitableState;
}