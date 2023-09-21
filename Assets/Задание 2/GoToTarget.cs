using UnityEngine;

public class GoToTarget : IState
{    
    private readonly IStateSwitcher _stateSwitcher;
    private readonly NPC _npc;
    private float _timeToChangeState = 4f;
    private float _currentStateTime = 0f;
    public GoToTarget(IStateSwitcher stateSwitcher, NPC npc)
    {
        _stateSwitcher = stateSwitcher;
        _npc = npc;
    }
    public void Enter()
    {
        Debug.Log("Начал идти к цели");
    }

    public void Exit()
    {
        Debug.Log("Дошел до цели");
    }

    public void Update()
    {
        Debug.Log("Иду к цели");
        _currentStateTime += Time.deltaTime;
        if (_currentStateTime > _timeToChangeState)
        {
            _currentStateTime = 0f;
            _stateSwitcher.SwitchState<WorkingState>();
        }
    }
}