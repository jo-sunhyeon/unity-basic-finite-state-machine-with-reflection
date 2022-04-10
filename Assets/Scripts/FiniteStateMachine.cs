using System;
using System.Reflection;
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
            Call("Exit");
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
        Call("Update");
    }
    
    private void CallStateEnter(TState state)
    {
        this.state = state;
        Call("Enter");
    }

    private void Call(string eventName)
    {
        monoBehaviour.GetType().GetMethod("On" + state + "State" + eventName,
            BindingFlags.Instance | BindingFlags.NonPublic).Invoke(monoBehaviour, new object[] {});
    }

    private MonoBehaviour monoBehaviour;
}
