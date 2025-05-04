namespace Demo;

class ThreadNetworkHostState : State
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.StringComp = StringComp.This;
        return true;
    }

    public virtual Demo Demo { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
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
        NetworkNetwork network;
        network = this.Network;

        Data data;
        data = new Data();
        data.Count = 5 * sizeof(uint);
        data.Init();

        Range range;
        range = new Range();
        range.Init();

        range.Index = 0;

        range.Count = 1;

        bool b;

        b = network.Stream.Read(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Host Case 0 Read Error\n"));
            return true;
        }

        range.Count = 1;

        long kk;
        kk = data.Get(0);

        bool ba;
        ba = (kk == 58);

        if (!ba)
        {
            Console.This.Err.Write(this.S("Network Host Case 0 Read Data Unvalid\n"));
            return false;
        }

        Console.This.Out.Write(this.S("Network Host Case 0 Success\n"));

        data.Set(0, 1);

        range.Count = 1;

        b = network.Stream.Write(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Host Case 1 Write Error\n"));
            return true;
        }

        range.Count = 4;

        b = network.Stream.Read(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Host Case 1 Read Error\n"));
            return true;
        }

        long a0;
        long a1;
        long a2;
        long a3;
        a0 = data.Get(0);
        a1 = data.Get(1);
        a2 = data.Get(2);
        a3 = data.Get(3);

        ba = (a0 == 11 & a1 == 57 & a2 == 98 & a3 == 149);

        if (!ba)
        {
            Console.This.Err.Write(this.S("Network Host Case 1 Read Data Unvalid\n"));
            return false;
        }

        Console.This.Out.Write(this.S("Network Host Case 1 Success\n"));

        data.Set(0, 2);

        range.Count = 1;

        b = network.Stream.Write(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Host Case 2 Write Error\n"));
            return true;
        }

        range.Count = 20;

        b = network.Stream.Read(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Host Case 2 Read Error\n"));
            return true;
        }

        String ka;
        ka = this.StringComp.CreateData(data, null);

        ba = this.Demo.TextSame(this.Demo.TA(ka), this.Demo.TB(this.S("Fy Oi")));

        if (!ba)
        {
            Console.This.Err.Write(this.S("Network Host Case 2 Read Data Unvalid\n"));
            return false;
        }

        Console.This.Out.Write(this.S("Network Host Case 2 Success\n"));

        return true;
    }

    private String S(string o)
    {
        return this.TextInfra.S(o);
    }
}