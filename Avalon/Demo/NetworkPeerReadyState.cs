namespace Demo;

class NetworkPeerReadyState : State
{
    public override bool Init()
    {
        this.StringCreate = new StringCreate();
        this.StringCreate.Init();

        this.Data = new Data();
        this.Data.Count = 10;
        this.Data.Init();

        this.Range = new DataRange();
        this.Range.Init();
        return true;
    }

    public Demo Demo { get; set; }
    public ThreadNetworkHostState HostState { get; set; }

    private Data Data { get; set; }
    private DataRange Range { get; set; }
    private int Case { get; set; }
    private StringCreate StringCreate { get; set; }
    private int Status { get; set; }

    public override bool Execute()
    {
        bool b;
        b = this.ExecuteAll();
        if (!b)
        {
            this.HostState.ExitNetwork(this.Status);
        }
        return true;
    }

    private bool ExecuteAll()
    {
        Network peer;
        peer = this.Demo.Peer;

        long a;
        a = peer.ReadyCount;

        long count;
        count = 0;
        
        int cc;
        cc = this.Case;
        if (cc == 0)
        {
            count = 1;
        }
        if (cc == 1)
        {
            count = 4;
        }
        if (cc == 2)
        {
            count = 10;
        }

        if (a < count)
        {
            return true;
        }

        Data data;
        data = this.Data;

        DataRange range;
        range = this.Range;
        range.Index = 0;
        range.Count = count;

        peer.Stream.Read(data, range);

        range.Count = 1;

        if (cc == 0)
        {
            int kk;
            kk = data.Get(0);

            bool b;
            b = (kk == 58);
            if (b)
            {
                Console.This.Out.Write("Network Server Case 0 Success\n");

                this.Case = 1;

                data.Set(0, this.Case);

                peer.Stream.Write(data, range);
            }
            if (!b)
            {
                Console.This.Err.Write("Network Server Case 0 Read Data Invalid\n");
                this.Status = 22;
                return false;
            }
        }

        if (cc == 1)
        {
            int a0;
            int a1;
            int a2;
            int a3;
            a0 = data.Get(0);
            a1 = data.Get(1);
            a2 = data.Get(2);
            a3 = data.Get(3);

            bool ba;
            ba = (a0 == 11 & a1 == 57 & a2 == 98 & a3 == 149);
            if (ba)
            {
                Console.This.Out.Write("Network Server Case 1 Success\n");

                this.Case = 2;

                data.Set(0, this.Case);

                peer.Stream.Write(data, range);

                return true;
            }
            if (!ba)
            {
                Console.This.Err.Write("Network Server Case 1 Read Data Invalid\n");
                this.Status = 24;
                return false;
            }
        }

        if (cc == 2)
        {
            string ka;
            ka = this.StringCreate.Data(data, null);

            Console.This.Out.Write("Network Server Case 2 Read Text: " + ka + "\n");

            this.HostState.ExitNetwork(0);
            return true;
        }
        return true;
    }
}