namespace Demo;

class ThreadNetworkHostState : ThreadExecuteState
{
    public Demo Demo { get; set; }

    public override bool Execute()
    {
        NetworkPortKindList portKindList;
        portKindList = this.Demo.NetworkPortKindList;

        NetworkPort port;
        port = new NetworkPort();
        port.Init();
        port.Kind = portKindList.LocalHost;
        port.Host = 50400;

        NetworkHost host;
        host = new NetworkHost();
        host.Init();

        this.Demo.Host = host;

        host.Port = port;

        NetworkNewPeerState state;
        state = new NetworkNewPeerState();
        state.Demo = this.Demo;
        state.HostState = this;
        state.Init();

        host.NewPeerState = state;

        TimeEvent varEvent;
        varEvent = new TimeEvent();
        varEvent.Init();

        varEvent.SingleShot = true;
        varEvent.Time = 0;

        NetworkHostOpenState openState;
        openState = new NetworkHostOpenState();
        openState.ThreadNetworkHostState = this;
        openState.Init();

        varEvent.Elapse.State.AddState(openState);

        varEvent.Start();

        ThreadCurrent current;
        current = new ThreadCurrent();
        current.Init();

        ThreadThread thread;
        thread = current.Thread;

        int o;
        o = thread.ExecuteEventLoop();

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

        Console.This.Out.Write("Network Host " + k + ", code: " + o + "\n");
        return true;
    }

    public bool ExitNetwork(int code)
    {
        Network peer;
        peer = this.Demo.Peer;

        this.Demo.Host.ClosePeer(peer);

        this.Demo.Host.Close();

        this.Demo.Host.Final();

        this.Demo.Peer = null;
        this.Demo.Host = null;

        ThreadCurrent current;
        current = new ThreadCurrent();
        current.Init();
        ThreadThread thread;
        thread = current.Thread;

        thread.ExitEventLoop(code);
        return true;
    }
}