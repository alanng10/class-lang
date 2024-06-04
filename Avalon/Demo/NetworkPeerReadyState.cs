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

    private Data Data { get; set; }
    private DataRange Range { get; set; }
    private int Case { get; set; }
    private StringCreate StringCreate { get; set; }

    public override bool Execute()
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

        if (!(peer.Stream.Status == 0))
        {
            Console.This.Err.Write("Network Server Peer Stream Status Error: " + peer.Stream.Status + "\n");
            return true;
        }

        if (cc == 0)
        {
            int kk;
            kk = data.Get(0);
            bool b;
            b = (kk == 58);
            if (b)
            {
                this.Case = 1;
            }
            if (!b)
            {
                Console.This.Err.Write("Network Server Peer Case 0 Read Data Invalid\n");
                return true;
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
                this.Case = 2;
            }
            if (!ba)
            {
                Console.This.Err.Write("Network Server Peer Case 1 Read Data Invalid\n");
                return true;
            }
        }

        if (cc == 2)
        {
            string ka;
            ka = this.StringCreate.Data(data, null);

            Console.This.Out.Write("Network Server Peer Case 2 Read Text: " + ka + "\n");

            this.Demo.Server.ClosePeer(peer);

            this.Demo.Server.Close();

            this.Demo.Peer = null;
            this.Demo.Server = null;
        }
        return true;
    }
}