public class BootstrapState : IState
{
    private readonly IStateMachine _gameStateMachine;

    public BootstrapState(IStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }
    
    public void Exit()
    {
        UnityEngine.Debug.Log("Exited Bootstrap State");
    }

    public void Enter()
    {
        UnityEngine.Debug.Log("Entered Bootstrap State");
        
        InitServices();
        
        _gameStateMachine.Enter<LoadGameState>();
    }

    private void InitServices()
    {
        DIContainer.Container.RegisterService<IInputService>(new InputService());
    }
}