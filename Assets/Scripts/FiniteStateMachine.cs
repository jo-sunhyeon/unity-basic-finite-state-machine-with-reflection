using System;
using UnityEngine;

public class FiniteStateMachine<TState> : IFiniteStateMachine where TState : Enum
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
            CallStateEnter(value);
        }
    }
    private TState state;

    public FiniteStateMachine(MonoBehaviour monoBehaviour, TState initialState)
    {
        this.monoBehaviour = monoBehaviour;
        CallStateEnter(initialState);
    }

    public void Update()
    {
        monoBehaviour.Invoke("On" + state.ToString() + "StateUpdate", 0);
    }
    
    private void CallStateEnter(TState state)
    {
        this.state = state;
        monoBehaviour.Invoke("On" + state.ToString() + "StateEnter", 0);
    }

    private MonoBehaviour monoBehaviour;
}
