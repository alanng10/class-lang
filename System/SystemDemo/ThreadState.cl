class ThreadState : State
{
    field prusate Phore Phore { get { return data; } set { data : value; } }

    maide prusate Bool Execute()
    {
        var TimeEventA timeEvent;
        timeEvent : new TimeEventA;
        timeEvent.Init();

        timeEvent.Time : 3 * 1000;

        timeEvent.Phore : this.Phore;

        timeEvent.Start();

        share Console.Out.Write("Thread State ExecuteMain Start\n");

        var ThreadThis threadThis;
        threadThis : new TheradThis;
        threadThis.Init();

        threadThis.Thread.ExecuteMain();

        share Console.Out.Write("Thread State ExecuteMain End\n");

        timeEvent.Final();

        return true;
    }
}