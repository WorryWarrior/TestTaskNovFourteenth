using UnityEngine;

public class RootBinding : MonoBehaviour
{
    private void Awake()
    {
        BindStateMachine();
    }

    private void BindStateMachine()
    {
        DIContainer.Container.RegisterService<IStateMachine>(new GameStateMachine());
    }
}