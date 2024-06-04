namespace Demo;

class ThreadNetworkState : ThreadExecuteState
{
    public Demo Demo { get; set; }
    public Network Network { get; set; }
    public NetworkReadyState ReadyState { get; set; }

    public override bool Execute()
    {
        string hostName;
        hostName = "localhost";
        int serverPort;
        serverPort = 50400;

        Network network;
        network = new Network();
        network.Init();

        network.HostName = hostName;
        network.ServerPort = serverPort;

        this.Network = network;

        NetworkCaseChangedState aa;
        aa = new NetworkCaseChangedState();
        aa.NetworkState = this;
        aa.Init();

        network.CaseChangedState = aa;

        NetworkReadyState ab;
        ab = new NetworkReadyState();
        ab.NetworkState = this;
        ab.Init();

        this.ReadyState = ab;

        network.ReadyReadState = ab;

        network.Open();

        ThreadCurrent current;
        current = new ThreadCurrent();
        current.Init();

        ThreadThread thread;
        thread = current.Thread;

        int o;
        o = thread.ExecuteEventLoop();

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

        Console.This.Out.Write("Network " + k + "\n");
        return true;
    }
}