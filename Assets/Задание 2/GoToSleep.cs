using UnityEngine;

public class GoToSleep : IState
{    
    private readonly IStateSwitcher _stateSwitcher;
    private readonly NPC _npc;
    private float _timeToChangeState = 4f;
    private float _currentStateTime = 0f;
    public GoToSleep(IStateSwitcher stateSwitcher, NPC npc)
    {
        _stateSwitcher = stateSwitcher;
        _npc = npc;
    }
    public void Enter()
    {
        Debug.Log("Пошел спать");
    }

    public void Exit()
    {
        Debug.Log("Дошел до кровати");
    }

    public void Update()
    {
        Debug.Log("Иду к кровати");
        _currentStateTime += Time.deltaTime;
        if (_currentStateTime > _timeToChangeState)
        {
            _currentStateTime = 0f;
            _stateSwitcher.SwitchState<SleepState>();
        }
    }
}