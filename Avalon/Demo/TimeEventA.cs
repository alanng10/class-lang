namespace Demo;

class TimeEventA : TimeEvent
{
    public virtual Demo Demo { get; set; }
    public virtual long ElapseCount { get; set; }
    public virtual ThreadPhore Phore { get; set; }
    private long Count { get; set; }

    public override bool Elapse()
    {
        Console console;
        console = Console.This;
        console.Out.Write(this.S("TimeEvent Elapse START\n"));

        this.Count = this.Count + 1;

        console.Out.Write(this.S("Elapse Count: " + this.Count + "\n"));

        //if (!(this.Count < this.ElapseCount))
        //{
            this.Stop();

            this.Phore.Close();

            console.Out.Write(this.S("TimeEvent Stop\n"));
        //}

        console.Out.Write(this.S("TimeEvent Elapse END\n"));

        return true;
    }

    protected virtual String S(string o)
    {
        return this.Demo.S(o);
    }
}