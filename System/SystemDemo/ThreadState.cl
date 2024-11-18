class ThreadState : State
{
    field prusate Phore Phore { get { return data; } set { data : value; } }

    maide prusate Bool Execute()
    {
        var TimeEventA timeEvent;
        timeEvent : new TimeEventA;
        timeEvent.Init();

        timeEvent.Time : 1 * 1000;

        timeEvent.ThreadState : this;
        timeEvent.Phore : this.Phore;

        timeEvent.Start();

        share Console.Out.Write("Thread State ExecuteMain Start\n");

        var ThreadThis threadThis;
        threadThis : new ThreadThis;
        threadThis.Init();

        var Int a;
        a : threadThis.Thread.ExecuteMain();

        share Console.Out.Write("Thread State ExecuteMain End\n");

        timeEvent.Final();

        this.Result : a;

        return true;
    }
}