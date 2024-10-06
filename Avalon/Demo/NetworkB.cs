namespace Demo;

class NetworkB : NetworkNetwork
{
    public override bool Init()
    {
        base.Init();

        this.Data = new Data();
        this.Data.Count = 10;
        this.Data.Init();

        this.Range = new Range();
        this.Range.Init();
        return true;
    }

    public ThreadNetworkHostState ThreadState { get; set; }

    private Data Data { get; set; }
    private Range Range { get; set; }
    private long Stage { get; set; }
    private long StatusCode { get; set; }

    public override bool StatusEvent()
    {
        bool b;
        b = this.StatusExecute();
        if (!b)
        {
            this.ThreadState.ExitNetwork(this.StatusCode);
        }
        return true;
    }

    private bool StatusExecute()
    {
        NetworkStatusList statusList;
        statusList = this.ThreadState.Demo.NetworkStatusList;

        if (!(this.Status == statusList.NoError))
        {
            this.StatusCode = 160;
            return false;
        }

        return true;
    }

    public override bool DataEvent()
    {
        bool b;
        b = this.DataExecute();
        if (!b)
        {
            this.ThreadState.ExitNetwork(this.StatusCode);
        }
        return true;
    }

    private bool DataExecute()
    {
        long a;
        a = this.ReadyCount;

        long count;
        count = 0;

        long cc;
        cc = this.Stage;
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

        Range range;
        range = this.Range;
        range.Index = 0;
        range.Count = count;

        this.Stream.Read(data, range);

        range.Count = 1;

        if (cc == 0)
        {
            long kk;
            kk = data.Get(0);

            bool b;
            b = (kk == 58);
            if (b)
            {
                Console.This.Out.Write(this.S("Network Host Case 0 Success\n"));

                this.Stage = 1;

                data.Set(0, this.Stage);

                this.Stream.Write(data, range);
            }
            if (!b)
            {
                Console.This.Err.Write(this.S("Network Host Case 0 Read Data Invalid\n"));
                this.StatusCode = 22;
                return false;
            }
        }

        if (cc == 1)
        {
            long a0;
            long a1;
            long a2;
            long a3;
            a0 = data.Get(0);
            a1 = data.Get(1);
            a2 = data.Get(2);
            a3 = data.Get(3);

            bool ba;
            ba = (a0 == 11 & a1 == 57 & a2 == 98 & a3 == 149);
            if (ba)
            {
                Console.This.Out.Write(this.S("Network Host Case 1 Success\n"));

                this.Stage = 2;

                data.Set(0, this.Stage);

                this.Stream.Write(data, range);

                return true;
            }
            if (!ba)
            {
                Console.This.Err.Write(this.S("Network Host Case 1 Read Data Invalid\n"));
                this.StatusCode = 24;
                return false;
            }
        }

        if (cc == 2)
        {
            String ka;
            ka = this.ThreadState.Demo.StringComp.CreateData(data, null);

            String kaa;
            kaa = this.AddClear().AddS("Network Host Case 2 Read Text: ").Add(ka).AddS("\n").AddResult();

            Console.This.Out.Write(kaa);

            this.ThreadState.ExitNetwork(0);
            return true;
        }
        return true;
    }

    public virtual NetworkB Add(String a)
    {
        this.ThreadState.Demo.Add(a);
        return this;
    }

    public virtual NetworkB AddS(string o)
    {
        this.ThreadState.Demo.AddS(o);
        return this;
    }

    public virtual NetworkB AddClear()
    {
        this.ThreadState.Demo.AddClear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.ThreadState.Demo.AddResult();
    }

    public virtual String S(string o)
    {
        return this.ThreadState.Demo.S(o);
    }
}