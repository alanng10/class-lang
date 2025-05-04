namespace Demo;

class ThreadNetworkHostState : State
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    private NetworkNetwork Network { get; set; }

    public override bool Execute()
    {
        TimeEvent timeEvent;
        timeEvent = new TimeEvent();
        timeEvent.Init();

        NetworkPort port;
        port = new NetworkPort();
        port.Init();
        port.ValueA = 0x0100007f;
        port.Host = 50920;

        NetworkHost host;
        host = new NetworkHost();
        host.Init();

        host.Port = port;

        bool b;
        b = host.Open();

        if (!b)
        {
            Console.This.Out.Write(this.S("Network Host Open Error\n"));
        }

        while (!host.Reque())
        {
            timeEvent.Wait(100);
        }

        NetworkNetwork network;

        network = host.OpenPeer();

        if (network == null)
        {
            Console.This.Out.Write(this.S("Network Host Open Peer Error\n"));
        }

        if (!(network == null))
        {
            Console.This.Out.Write(this.S("Network Host Open Peer Success\n"));

            this.Network = network;

            this.ExecuteNetwork();

            this.Network = null;
        }

        host.Close();

        host.Final();

        timeEvent.Final();

        Console.This.Out.Write(this.S("Network Host End\n"));
        return true;
    }

    private bool ExecuteNetwork()
    {
        return true;
    }

    private String S(string o)
    {
        return this.TextInfra.S(o);
    }
}