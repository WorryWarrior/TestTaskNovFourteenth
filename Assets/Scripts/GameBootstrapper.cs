using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private void Start()
    {
        IStateMachine gameStateMachine = DIContainer.Container.GetService<IStateMachine>();
        
        gameStateMachine.RegisterState(new BootstrapState(gameStateMachine));
        gameStateMachine.RegisterState(new LoadGameState());
        
        gameStateMachine.Enter<BootstrapState>();
        
        DontDestroyOnLoad(this);
    }
}