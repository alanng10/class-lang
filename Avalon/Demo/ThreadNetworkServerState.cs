namespace Demo;

class ThreadNetworkServerState : ThreadExecuteState
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
        port.Server = 50400;

        NetworkServer server;
        server = new NetworkServer();
        server.Init();

        this.Demo.Server = server;

        server.Port = port;

        NetworkNewPeerState state;
        state = new NetworkNewPeerState();
        state.Demo = this.Demo;
        state.ServerState = this;
        state.Init();

        server.NewPeerState = state;

        TimeInterval interval;
        interval = new TimeInterval();
        interval.Init();

        interval.SingleShot = true;
        interval.Time = 0;

        NetworkServerOpenState openState;
        openState = new NetworkServerOpenState();
        openState.ThreadNetworkServerState = this;
        openState.Init();

        interval.Elapse.State.AddState(openState);

        interval.Start();

        ThreadCurrent current;
        current = new ThreadCurrent();
        current.Init();

        ThreadThread thread;
        thread = current.Thread;

        int o;
        o = thread.ExecuteEventLoop();

        interval.Final();

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

        Console.This.Out.Write("Network Server " + k + ", code: " + o + "\n");
        return true;
    }

    public bool ExitNetwork(int code)
    {
        Network peer;
        peer = this.Demo.Peer;

        this.Demo.Server.ClosePeer(peer);

        this.Demo.Server.Close();

        this.Demo.Server.Final();

        this.Demo.Peer = null;
        this.Demo.Server = null;

        ThreadCurrent current;
        current = new ThreadCurrent();
        current.Init();
        ThreadThread thread;
        thread = current.Thread;

        thread.ExitEventLoop(code);
        return true;
    }
}