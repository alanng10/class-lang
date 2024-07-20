namespace Demo;

public class ThreadNetworkState : ThreadExecuteState
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.NetworkStatusList = NetworkStatusList.This;
        this.NetworkCaseList = NetworkCaseList.This;
        return true;
    }

    public TextInfra TextInfra { get; set; }
    public NetworkStatusList NetworkStatusList { get; set; }
    public NetworkCaseList NetworkCaseList { get; set; }
    public Network Network { get; set; }
    public NetworkReadyState ReadyState { get; set; }

    public override bool Execute()
    {
        string hostName;
        hostName = "localhost";
        int hostPort;
        hostPort = 50400;

        Network network;
        network = new Network();
        network.Init();

        network.HostName = hostName;
        network.HostPort = hostPort;

        this.Network = network;

        NetworkStatusState aa;
        aa = new NetworkStatusState();
        aa.NetworkState = this;
        aa.Init();

        network.StatusChangeState = aa;

        NetworkCaseState ab;
        ab = new NetworkCaseState();
        ab.NetworkState = this;
        ab.Init();

        network.CaseChangeState = ab;

        NetworkReadyState ac;
        ac = new NetworkReadyState();
        ac.NetworkState = this;
        ac.Init();

        network.ReadyReadState = ac;

        this.ReadyState = ac;

        network.Open();

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        ThreadThread thread;
        thread = varThis.Thread;

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

        Console.This.Out.Write("Network " + k + ", code: " + o + "\n");
        return true;
    }

    public bool ExitNetwork(int code)
    {
        Network network;
        network = this.Network;

        network.Close();

        network.Final();

        this.Network = null;

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();
        ThreadThread thread;
        thread = varThis.Thread;

        thread.ExitEventLoop(code);
        return true;
    }
}