namespace Demo;

public class NetworkState : State
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.StringComp = StringComp.This;
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    private NetworkNetwork Network { get; set; }
    private TimeEvent TimeEvent { get; set; }

    public override bool Execute()
    {
        TimeEvent timeEvent;
        timeEvent = new TimeEvent();
        timeEvent.Init();

        this.TimeEvent = timeEvent;

        String hostName;
        hostName = this.S("localhost");
        long hostPort;
        hostPort = 50920;

        NetworkNetwork network;
        network = new NetworkNetwork();
        network.Init();

        network.HostName = hostName;
        network.HostPort = hostPort;

        bool b;
        b = network.Open();

        if (!b)
        {
            Console.This.Out.Write(this.S("Network Open Error\n"));
            return true;
        }

        this.Network = network;

        this.ExecuteNetwork();

        this.Network = null;
 
        network.Close();

        Console.This.Out.Write(this.S("Network Close\n"));

        network.Final();

        this.TimeEvent = null;

        timeEvent.Final();

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

        data.Set(0, 58);

        range.Count = 1;

        bool b;
        b = network.Stream.Write(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Case 0 Write Error\n"));
            return true;
        }

        range.Index = 0;
        range.Count = 1;

        this.WaitAvail(range.Count);

        b = network.Stream.Read(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Case 0 Read Error\n"));
            return true;
        }

        long kk;
        kk = data.Get(0);

        bool ba;
        ba = (kk == 1);

        if (!ba)
        {
            Console.This.Err.Write(this.S("Network Case 0 Read Data Unvalid\n"));
            return true;
        }

        Console.This.Out.Write(this.S("Network Case 0 Success\n"));

        data.Set(0, 11);
        data.Set(1, 57);
        data.Set(2, 98);
        data.Set(3, 149);

        range.Count = 4;

        b = network.Stream.Write(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Case 1 Write Error\n"));
            return true;
        }

        range.Count = 1;

        this.WaitAvail(range.Count);

        b = network.Stream.Read(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Case 1 Read Error\n"));
            return true;
        }

        kk = data.Get(0);

        ba = (kk == 2);

        if (!ba)
        {
            Console.This.Err.Write(this.S("Network Case 1 Read Data Unvalid\n"));
            return true;
        }

        Console.This.Out.Write(this.S("Network Case 1 Success\n"));

        TextInfra textInfra;
        textInfra = this.TextInfra;

        String oo;
        oo = this.S("Fy Oi");

        long countA;
        countA = this.StringComp.Count(oo);
        long i;
        i = 0;
        while (i < countA)
        {
            long nn;
            nn = this.StringComp.Char(oo, i);

            textInfra.DataCharSet(data, i, nn);

            i = i + 1;
        }

        range.Count = data.Count;

        b = network.Stream.Write(data, range);

        if (!b)
        {
            Console.This.Err.Write(this.S("Network Case 2 Write Error\n"));
            return true;
        }

        return true;
    }

    private bool WaitAvail(long count)
    {
        while (this.Network.Avail < count)
        {
            this.TimeEvent.Wait(100);
        }
        return true;
    }

    private String S(string o)
    {
        return this.TextInfra.S(o);
    }
}