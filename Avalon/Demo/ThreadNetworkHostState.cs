namespace Demo;

class ThreadNetworkHostState : State
{
    public Demo Demo { get; set; }

    public virtual TimeEvent TimeEvent { get; set; }

    public override bool Execute()
    {
        NetworkPortKindList portKindList;
        portKindList = this.Demo.NetworkPortKindList;

        NetworkPort port;
        port = new NetworkPort();
        port.Init();
        port.Kind = portKindList.LocalHost;
        port.Host = 50920;

        NetworkHostA host;
        host = new NetworkHostA();
        host.Init();
        host.ThreadState = this;
        host.Demo = this.Demo;

        this.Demo.Host = host;

        host.Port = port;

        TimeEvent varEvent;
        varEvent = new TimeEvent();
        varEvent.Init();
        varEvent.Time = 0;

        this.TimeEvent = varEvent;

        NetworkHostOpenState openState;
        openState = new NetworkHostOpenState();
        openState.ThreadNetworkHostState = this;
        openState.Init();

        varEvent.Elapse.State.AddState(openState);

        varEvent.Start();

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        ThreadThread thread;
        thread = varThis.Thread;

        long o;
        o = thread.ExecuteMain();

        varEvent.Final();

        string k;
        k = null;
        bool b;
        b = (o == 0);
        if (b)
        {
            k = "Success";
        }
        if (!b)
        {
            k = "Fail";
        }

        Console.This.Out.Write(this.Demo.S("Network Host " + k + ", code: " + o + "\n"));
        return true;
    }

    public bool ExitNetwork(long code)
    {
        NetworkNetwork peer;
        peer = this.Demo.Peer;

        this.Demo.Host.ClosePeer(peer);

        this.Demo.Host.Close();

        this.Demo.Host.Final();

        this.Demo.Peer = null;
        this.Demo.Host = null;

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();
        ThreadThread thread;
        thread = varThis.Thread;

        thread.Exit(code);
        return true;
    }
}