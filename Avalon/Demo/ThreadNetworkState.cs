namespace Demo;

public class ThreadNetworkState : State
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
    public NetworkA Network { get; set; }

    public override bool Execute()
    {
        String hostName;
        hostName = this.S("localhost");
        long hostPort;
        hostPort = 50920;

        NetworkA network;
        network = new NetworkA();
        network.Init();

        network.ThreadState = this;

        network.HostName = hostName;
        network.HostPort = hostPort;

        this.Network = network;

        network.Open();

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        ThreadThread thread;
        thread = varThis.Thread;

        long o;
        o = thread.ExecuteMain();

        network.Final();

        this.Network = null;

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

        Console.This.Out.Write(this.S("Network " + k + ", code: " + o + "\n"));
        return true;
    }

    public bool ExitNetwork(long code)
    {
        NetworkA network;
        network = this.Network;

        network.Close();

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();
        ThreadThread thread;
        thread = varThis.Thread;

        thread.Exit(code);
        return true;
    }

    private String S(string o)
    {
        return this.TextInfra.S(o);
    }
}