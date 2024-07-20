namespace Demo;

class ElapseState : State
{
    public TimeEvent TimeEvent { get; set; }
    public ThreadThread Thread { get; set; }
    public int ElapseCount { get; set; }
    public int ExitCode { get; set; }

    private int Count { get; set; }
    
    public override bool Execute()
    {
        Console console;
        console = Console.This;
        console.Out.Write("ElapseState.Execute START\n");

        this.Count = this.Count + 1;

        console.Out.Write("Elapse Count: " + this.Count + "\n");
         
        if (!(this.Count < this.ElapseCount))
        {
            if (!this.TimeEvent.SingleShot)
            {
                this.TimeEvent.Stop();

                console.Out.Write("ElapseState.Execute Interval Stop\n");
            }

            this.Thread.ExitEventLoop(this.ExitCode);
        }

        console.Out.Write("ElapseState.Execute END\n");

        return true;
    }
}