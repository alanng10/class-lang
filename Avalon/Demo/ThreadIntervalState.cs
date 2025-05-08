namespace Demo;

class TimeEventState : State
{
    public virtual Demo Demo { get; set; }
    public long ElapseCount { get; set; }
    public long Time { get; set; }
    public long ExitCode { get; set; }

    public override bool Execute()
    {
        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        ThreadThread thread;
        thread = varThis.Thread;

        TimeEventA varEvent;
        varEvent = new TimeEventA();
        varEvent.Init();
        varEvent.Demo = this.Demo;
        varEvent.Thread = thread;
        varEvent.ElapseCount = this.ElapseCount;
        varEvent.ExitCode = this.ExitCode;

        varEvent.Time = this.Time;

        varEvent.Start();

        long o;        
        o = thread.ExecuteMain();

        varEvent.Final();
        
        Value aa;
        aa = new Value();
        aa.Init();
        aa.Int = o;
        this.Result = aa;
        return true;
    }
}