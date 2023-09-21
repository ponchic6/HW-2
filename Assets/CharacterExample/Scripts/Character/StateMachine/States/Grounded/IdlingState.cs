using UnityEngine;

public class IdlingState : GroundedState
{
    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartIdling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdling();  
    }

    public override void Update()
    {
        base.Update();
        Debug.Log(2);
        if (IsHorizontalInputZero())
        {
            return;
        }
        
        if (!IsHorizontalInputZero() && IsFastRunButtonHoldDown())
        {
            StateSwitcher.SwitchState<FastRunningState>();
            return;
        }

        if (!IsHorizontalInputZero())
        {
            StateSwitcher.SwitchState<SlowRunningState>();
            Debug.Log(1111);
            return;
        }
    }
}
