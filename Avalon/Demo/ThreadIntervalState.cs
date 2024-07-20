namespace Demo;

class ThreadIntervalState : ThreadExecuteState
{
    public bool SingleShot { get; set; }
    public int ElapseCount { get; set; }
    public long Time { get; set; }
    public int ExitCode { get; set; }

    public override bool Execute()
    {
        ThreadCurrent current;
        current = new ThreadCurrent();
        current.Init();

        TimeEvent varEvent;
        varEvent = new TimeEvent();
        varEvent.Init();

        ThreadThread thread;
        thread = current.Thread;

        ElapseState state;
        state = new ElapseState();
        state.Init();
        state.TimeEvent = varEvent;
        state.Thread = thread;
        state.ElapseCount = this.ElapseCount;
        state.ExitCode = this.ExitCode;

        varEvent.Time = this.Time;
        varEvent.SingleShot = this.SingleShot;
        varEvent.Elapse.State.AddState(state);

        varEvent.Start();

        int o;        
        o = thread.ExecuteEventLoop();

        varEvent.Final();
        
        this.Result = o;
        return true;
    }
}