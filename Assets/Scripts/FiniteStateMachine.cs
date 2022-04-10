using System;
using UnityEngine;

public class FiniteStateMachine<TState> : IFiniteStateMachine where TState : struct, Enum
{
    public TState State
    {
        get
        {
            return state;
        }
        set
        {
            monoBehaviour.Invoke("On" + state.ToString() + "StateExit", 0);
            state = value;
            monoBehaviour.Invoke("On" + state.ToString() + "StateEnter", 0);
        }
    }
    private TState state;

    public FiniteStateMachine(MonoBehaviour monoBehaviour, TState initialState)
    {
        this.monoBehaviour = monoBehaviour;
        state = initialState;
        monoBehaviour.Invoke("On" + state.ToString() + "StateEnter", 0);
    }

    public void Update()
    {
        monoBehaviour.Invoke("On" + state.ToString() + "StateUpdate", 0);
    }

    private void OnDestroy()
    {
        monoBehaviour.Invoke("On" + state.ToString() + "StateExit", 0);
    }

    private MonoBehaviour monoBehaviour;
}
