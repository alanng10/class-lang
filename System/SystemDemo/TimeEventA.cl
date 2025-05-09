class TimeEventA : TimeEvent
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Count : 0;
        return true;
    }

    field prusate ThreadState ThreadState { get { return data; } set { data : value; } }
    field prusate Phore Phore { get { return data; } set { data : value; } }
    field private Int Count { get { return data; } set { data : value; } }

    maide prusate Bool Elapse()
    {
        share Console.Out.Write(this.ThreadState.AddClear().Add("Time Event Elapse Index: ")
            .Add(this.ThreadState.StringInt(this.Count)).AddLine().AddResult());

        this.Count : this.Count + 1;

        inf (this.Count = 3)
        {
            this.Stop();

            this.Phore.Close();

            share Console.Out.Write("TimeEvent Elapse Phore Close\n");

            var ThreadThis threadThis;
            threadThis : new ThreadThis;
            threadThis.Init();

            threadThis.Thread.Exit(93824);
        }

        return true;
    }
}