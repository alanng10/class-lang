namespace Demo;

public class NetworkA : NetworkNetwork
{
    public override bool Init()
    {
        base.Init();

        this.TextInfra = TextInfra.This;

        this.Data = new Data();
        this.Data.Count = 10;
        this.Data.Init();

        this.Range = new Range();
        this.Range.Init();
        return true;
    }

    public Data Data { get; set; }
    public Range Range { get; set; }

    public virtual ThreadNetworkState ThreadState { get; set; }

    public virtual long StatusCode { get; set; }
    public virtual long Stage { get; set; }

    protected virtual TextInfra TextInfra { get; set; }

    public override bool CaseEvent()
    {
        NetworkCaseList caseList;
        caseList = this.ThreadState.NetworkCaseList;

        if (this.Case == caseList.Connected)
        {
            Data data;
            data = this.Data;

            Range range;
            range = this.Range;

            data.Set(0, 58);

            range.Count = 1;

            this.Stream.Write(data, range);
        }

        if (this.Case == caseList.Unconnected)
        {
        }

        return true;
    }

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
        statusList = this.ThreadState.NetworkStatusList;

        if (!(this.Status == statusList.NoError))
        {
            this.StatusCode = 4000 + this.Status.Index;
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
            count = 1;
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

        if (cc == 0)
        {
            long kk;
            kk = data.Get(0);

            bool b;
            b = (kk == 1);
            if (b)
            {
                Console.This.Out.Write(this.S("Network Case 0 Success\n"));

                this.Stage = 1;

                data.Set(0, 11);
                data.Set(1, 57);
                data.Set(2, 98);
                data.Set(3, 149);

                range.Count = 4;

                this.Stream.Write(data, range);
            }
            if (!b)
            {
                Console.This.Err.Write(this.S("Network Case 0 Read Data Invalid\n"));
                this.StatusCode = 12;
                return false;
            }
        }

        if (cc == 1)
        {
            long kk;
            kk = data.Get(0);

            bool b;
            b = (kk == 2);
            if (b)
            {
                Console.This.Out.Write(this.S("Network Case 1 Success\n"));

                this.Stage = 2;

                TextInfra textInfra;
                textInfra = this.TextInfra;

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

                this.Stream.Write(data, range);

                this.ThreadState.ExitNetwork(0);
                return true;
            }
            if (!b)
            {
                Console.This.Err.Write(this.S("Network Case 1 Read Data Invalid\n"));
                this.StatusCode = 14;
                return false;
            }
        }
        return true;
    }

    private String S(string o)
    {
        return this.TextInfra.S(o);
    }
}