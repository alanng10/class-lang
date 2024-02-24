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

        TimeInterval interval;
        interval = new TimeInterval();
        interval.Init();

        ThreadThread thread;
        thread = current.Thread;

        ElapseState state;
        state = new ElapseState();
        state.Init();
        state.Interval = interval;
        state.Thread = thread;
        state.ElapseCount = this.ElapseCount;
        state.ExitCode = this.ExitCode;

        interval.Time = this.Time;
        interval.SingleShot = this.SingleShot;
        interval.Elapse.State.AddState(state);

        interval.Start();

        int o;        
        o = thread.ExecuteEventLoop();

        interval.Final();
        
        this.Result = o;
        return true;
    }
}