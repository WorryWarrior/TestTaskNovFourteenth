public class LoadGameState : IState
{
    public void Exit()
    {
        UnityEngine.Debug.Log("Exited Loading State");
    }

    public void Enter()
    {
        UnityEngine.Debug.Log("Entered Loading State");
    }
}