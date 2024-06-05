namespace Demo;

public class NetworkReadyState : State
{
    public override bool Init()
    {
        this.Data = new Data();
        this.Data.Count = 10;
        this.Data.Init();

        this.Range = new DataRange();
        this.Range.Init();
        return true;
    }

    public ThreadNetworkState NetworkState { get; set; }

    public Data Data { get; set; }
    public DataRange Range { get; set; }
    private int Case { get; set; }
    private int Status { get; set; }

    public override bool Execute()
    {
        bool b;
        b = this.ExecuteAll();
        if (!b)
        {
            this.NetworkState.ExitNetwork(this.Status);
        }
        return true;
    }

    private bool ExecuteAll()
    {
        Network network;
        network = this.NetworkState.Network;

        long a;
        a = network.ReadyCount;

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
            count = 1;
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

        network.Stream.Read(data, range);

        if (cc == 0)
        {
            int kk;
            kk = data.Get(0);

            bool b;
            b = (kk == 1);
            if (b)
            {
                Console.This.Out.Write("Network Case 0 Success\n");

                this.Case = 1;

                data.Set(0, 11);
                data.Set(1, 57);
                data.Set(2, 98);
                data.Set(3, 149);

                range.Count = 4;
                
                network.Stream.Write(data, range);
            }
            if (!b)
            {
                Console.This.Err.Write("Network Case 0 Read Data Invalid\n");
                this.Status = 12;
                return false;
            }
        }

        if (cc == 1)
        {
            int kk;
            kk = data.Get(0);

            bool b;
            b = (kk == 2);
            if (b)
            {
                Console.This.Out.Write("Network Case 1 Success\n");

                this.Case = 2;

                TextInfra textInfra;
                textInfra = this.NetworkState.TextInfra;

                string oo;
                oo = "Fy Oi";

                int countA;
                countA = oo.Length;
                int i;
                i = 0;
                while (i < countA)
                {
                    char oc;
                    oc = oo[i];

                    textInfra.DataCharSet(data, i, oc);

                    i = i + 1;
                }

                range.Count = 10;

                network.Stream.Write(data, range);

                this.NetworkState.ExitNetwork(0);
                return true;
            }
            if (!b)
            {
                Console.This.Err.Write("Network Case 1 Read Data Invalid\n");
                this.Status = 14;
                return false;
            }
        }
        return true;
    }
}