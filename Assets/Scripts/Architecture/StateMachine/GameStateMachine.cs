using System.Collections.Generic;

public class GameStateMachine : IStateMachine
{
    private readonly Dictionary<System.Type, IExitableState> _registeredStates;
    private IExitableState _currentState;

    public GameStateMachine()
    {
        _registeredStates = new Dictionary<System.Type, IExitableState>();
    }
        
    public void Enter<TState>() where TState : class, IState
    {
        TState state = ChangeState<TState>();
        state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
        TState state = ChangeState<TState>();
        state.Enter(payload);
    }

    public void RegisterState<TState>(TState state) where TState : IExitableState
    {
        _registeredStates.Add(typeof(TState), state);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _currentState?.Exit();
      
        TState state = GetState<TState>();
        _currentState = state;
      
        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState
    {
        return _registeredStates[typeof(TState)] as TState;
    }
}
