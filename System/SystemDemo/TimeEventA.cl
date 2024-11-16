class TimeEventA : TimeEvent
{
    field prusate Phore Phore { get { return data; } set { data : value; } }

    maide prusate Bool Elapse()
    {
        this.Stop();

        this.Phore.Close();

        share Console.Out.Write("Time Event Elapse Phore Close\n");

        var ThreadThis threadThis;
        threadThis : new ThreadThis;
        threadThis.Init();

        threadThis.Thread.Exit(0);

        return true;
    }
}