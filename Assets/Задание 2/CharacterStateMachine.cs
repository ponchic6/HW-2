using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public CharacterStateMachine(NPC npc)
    {
        _states = new List<IState>()
        {
            new SleepState(this, npc),
            new GoToTarget(this, npc),
            new WorkingState(this, npc),
            new GoToSleep(this, npc)
        };
        _currentState = _states[0];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);
        
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() =>
        _currentState.Update();
}