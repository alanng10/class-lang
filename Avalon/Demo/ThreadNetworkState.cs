namespace Demo;

public class ThreadNetworkState : State
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        return true;
    }

    public virtual TextInfra TextInfra { get; set; }
    private Data Data { get; set; }
    private Range Range { get; set; }

    public override bool Execute()
    {
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

        Data data;
        data = new Data();
        data.Count = 5 * sizeof(uint);
        data.Init();

        Range range;
        range = new Range();
        range.Init();

        data.Set(0, 58);

        range.Count = 1;

        network.Stream.Write(data, range);

        long stage;
        stage = 0;

        range.Index = 0;
        range.Count = 1;

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
            Console.This.Err.Write(this.S("Network Case 0 Read Data Invalid\n"));
            return true;
        }

        Console.This.Out.Write(this.S("Network Case 0 Success\n"));

        stage = 1;

        data.Set(0, 11);
        data.Set(1, 57);
        data.Set(2, 98);
        data.Set(3, 149);

        range.Count = 4;

        network.Stream.Write(data, range);

        range.Count = 1;

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
            Console.This.Err.Write(this.S("Network Case 1 Read Data Invalid\n"));
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

        this.Stream.Write(data, range);

        this.ThreadState.ExitNetwork(0);
        return true;
            
        network.Close();

        Console.This.Out.Write(this.S("Network Close\n"));

        network.Final();

        return true;
    }

    private String S(string o)
    {
        return this.TextInfra.S(o);
    }
}