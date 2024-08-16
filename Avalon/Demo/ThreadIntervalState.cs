namespace Demo;

class ThreadIntervalState : State
{
    public virtual Demo Demo { get; set; }
    public bool Single { get; set; }
    public int ElapseCount { get; set; }
    public long Time { get; set; }
    public int ExitCode { get; set; }

    public override bool Execute()
    {
        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        TimeEvent varEvent;
        varEvent = new TimeEvent();
        varEvent.Init();

        ThreadThread thread;
        thread = varThis.Thread;

        ElapseState state;
        state = new ElapseState();
        state.Init();
        state.Demo = this.Demo;
        state.TimeEvent = varEvent;
        state.Thread = thread;
        state.ElapseCount = this.ElapseCount;
        state.ExitCode = this.ExitCode;

        varEvent.Time = this.Time;
        varEvent.Single = this.Single;
        varEvent.Elapse.State.AddState(state);

        varEvent.Start();

        long o;        
        o = thread.ExecuteEventLoop();

        varEvent.Final();
        
        Value aa;
        aa = new Value();
        aa.Init();
        aa.Int = o;
        this.Result = aa;
        return true;
    }
}