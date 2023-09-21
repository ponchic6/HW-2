using UnityEngine;

public class SleepState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly NPC _npc;
    private float _timeToChangeState = 4f;
    private float _currentStateTime = 0f;
    public SleepState(IStateSwitcher stateSwitcher, NPC npc)
    {
        _stateSwitcher = stateSwitcher;
        _npc = npc;
    }
    public void Enter()
    {
        Debug.Log("Вошел в состояние отдыха");
    }

    public void Exit()
    {
        Debug.Log("Вышел из состояния отдыха");
    }

    public void Update()
    {
        Debug.Log("Отдыхаю....");
        _currentStateTime += Time.deltaTime;
        if (_currentStateTime > _timeToChangeState)
        {
            _currentStateTime = 0f;
            _stateSwitcher.SwitchState<GoToTarget>();
        }
    }
}