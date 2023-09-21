using UnityEngine;

public class WorkingState : IState
{    
    private readonly IStateSwitcher _stateSwitcher;
    private readonly NPC _npc;
    private float _timeToChangeState = 4f;
    private float _currentStateTime = 0f;
    public WorkingState(IStateSwitcher stateSwitcher, NPC npc)
    {
        _stateSwitcher = stateSwitcher;
        _npc = npc;
    }
    public void Enter()
    {
        Debug.Log("Начал работать");
    }

    public void Exit()
    {
        Debug.Log("Закончил работать");
    }

    public void Update()
    {
        Debug.Log("Работаю");
        _currentStateTime += Time.deltaTime;
        if (_currentStateTime > _timeToChangeState)
        {
            _currentStateTime = 0f;
            _stateSwitcher.SwitchState<GoToSleep>();
        }
    }
}