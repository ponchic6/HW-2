public class SlowRunningState : GroundedState
{
    private readonly RunningStateConfig _config;

    public SlowRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartRunning();

        Data.Speed = _config.SlowRunSpeed;
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }
    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
        
        if (IsFastRunButtonHoldDown()) 
            StateSwitcher.SwitchState<FastRunningState>();
    }
}
