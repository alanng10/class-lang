namespace Demo;

class ElapseState : State
{
    public virtual Demo Demo { get; set; }
    public TimeEvent TimeEvent { get; set; }
    public ThreadThread Thread { get; set; }
    public long ElapseCount { get; set; }
    public long ExitCode { get; set; }

    private long Count { get; set; }
    
    public override bool Execute()
    {
        Console console;
        console = Console.This;
        console.Out.Write(this.S("ElapseState.Execute START\n"));

        this.Count = this.Count + 1;

        console.Out.Write(this.S("Elapse Count: " + this.Count + "\n"));
         
        if (!(this.Count < this.ElapseCount))
        {
            if (!this.TimeEvent.Single)
            {
                this.TimeEvent.Stop();

                console.Out.Write(this.S("ElapseState.Execute Time Event Stop\n"));
            }

            this.Thread.ExitEventLoop(this.ExitCode);
        }

        console.Out.Write(this.S("ElapseState.Execute END\n"));

        return true;
    }

    protected virtual String S(string o)
    {
        return this.Demo.S(o);
    }
}