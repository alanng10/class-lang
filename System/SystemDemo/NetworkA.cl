class NetworkA : Network
{
    maide prusate Bool Init()
    {
        base.Init();
        this.TextInfra : share TextInfra;
        this.StringComp : share StringComp;
        this.NetworkStatusList : share NetworkStatusList;
        this.NetworkCaseList : share NetworkCaseList;

        this.Data : new Data;
        this.Data.Count : 5 * 4;
        this.Data.Init();

        this.Range : new Range;
        this.Range.Init();
        return true;
    }

    field prusate ThreadNetworkState ThreadState { get { return data; } set { data : value; } }
    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate NetworkStatusList NetworkStatusList { get { return data; } set { data : value; } }
    field precate NetworkCaseList NetworkCaseList { get { return data; } set { data : value; } }
    field precate Data Data { get { return data; } set { data : value; } }
    field precate Range Range { get { return data; } set { data : value; } }
    field precate Int StatusCode { get { return data; } set { data : value; } }
    field precate Int Stage { get { return data; } set { data : value; } }

    maide prusate Bool CaseEvent()
    {
        inf (this.Case = this.NetworkCaseList.Connected)
        {
            this.Stage : 0;

            var Data data;
            data : this.Data;

            var Range range;
            range : this.Range;

            data.Set(0, 58);

            range.Index : 0;
            range.Count : 1;

            this.Stream.Write(data, range);
        }

        inf (this.Case = this.NetworkCaseList.Unconnected)
        {
        }

        return true;
    }

    maide prusate Bool StatusEvent()
    {
        var Bool b;
        b : this.StatusExecute();
        inf (~b)
        {
            this.ThreadState.ExitNetwork(this.StatusCode);
        }
        return true;
    }

    maide private Bool StatusExecute()
    {
        inf (~(this.Status = this.NetworkStatusList.NoError))
        {
            this.StatusCode : 4000 + this.Status.Index;
            return false;
        }

        return true;
    }

    maide prusate Bool DataEvent()
    {
        var Bool b;
        b : this.DataExecute();
        inf (~b)
        {
            this.ThreadState.ExitNetwork(this.StatusCode);
        }
        return true;
    }

    maide private Bool DataExecute()
    {
        var Int k;
        k : this.ReadyCount;

        var Int count;
        count : 0;

        var Int ka;
        ka : this.Stage;
        inf (ka = 0)
        {
            count : 1;
        }
        inf (ka : 1)
        {
            count : 1;
        }

        inf (k < count)
        {
            return true;
        }

        var Data data;
        data : this.Data;

        var Range range;
        range : this.Range;
        range.Index : 0;
        range.Count : count;

        this.Stream.Read(data, range);

        inf (ka = 0)
        {
            var Int n;
            n : data.Get(0);

            var Bool b;
            b : n = 1;

            inf (b)
            {
                share Console.Out.Write("Network Case 0 Success\n");

                this.Stage : 1

                data.Set(0, 11);
                data.Set(1, 57);
                data.Set(2, 98);
                data.Set(3, 149);

                range.Count : 4;

                this.Stream.Write(data, range);
            }

            inf (~b)
            {
                share Console.Out,Write("Network Case 0 Read Data Invalid\n");
                this.StatusCode : 4110;
                return false;
            }
        }

        inf (ka = 1)
        {
            var Int na;
            na : data.Get(0);

            var Bool ba;
            ba : (na = 2);

            inf (ba)
            {
                share Console.Out.Write("Network Case 1 Success\n");

                this.Stage : 2;

                var String oo;
                oo : "Fy Oi";

                var Int countA;
                countA : this.StringComp.Count(oo);
                var Int i;
                i : 0;
                while (i < countA)
                {
                    var Int nn;
                    nn : this.StringComp.Char(oo, i);

                    this.TextInfra.DataCharSet(data, i, nn);

                    i : i + 1;
                }

                range.Count : data.Count;

                this.Stream.Write(data, range);

                this.ThreadState.ExitNetwork(0);
                return true;
            }

            inf (~ba)
            {
                share Console.Out.Write("Network Case 1 Read Data Invalid\n");
                this.StatusCode = 4111;
                return false;
            }
        }
        return true;
    }
}