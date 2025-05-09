class ThreadState : StateA
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

        var ThreadThis threadThis;
        threadThis : new ThreadThis;
        threadThis.Init();

        var Int a;
        a : threadThis.Thread.ExecuteMain();

        timeEvent.Final();

        this.Result : a;

        return true;
    }
}