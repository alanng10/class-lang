class NetworkB : Network
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

        this.Stage : 0;
        return true;
    }

    field prusate ThreadNetworkHostState ThreadState { get { return data; } set { data : value; } }
    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate NetworkStatusList NetworkStatusList { get { return data; } set { data : value; } }
    field precate NetworkCaseList NetworkCaseList { get { return data; } set { data : value; } }
    field precate Data Data { get { return data; } set { data : value; } }
    field precate Range Range { get { return data; } set { data : value; } }
    field precate Int StatusCode { get { return data; } set { data : value; } }
    field precate Int Stage { get { return data; } set { data : value; } }

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
            this.StatusCode : 4500 + this.Status.Index;
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
        inf (ka = 1)
        {
            count : 4;
        }
        inf (ka = 2)
        {
            count : 20;
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
            b : n = 58;

            inf (b)
            {
                share Console.Out.Write("Network Host Case 0 Success\n");

                this.Stage : 1;

                data.Set(0, this.Stage);

                range.Count : 1;

                this.Stream.Write(data, range);
            }

            inf (~b)
            {
                share Console.Out.Write("Network Host Case 0 Read Data Invalid\n");
                this.StatusCode : 4610;
                return false;
            }
        }

        inf (ka = 1)
        {
            var Int n0;
            var Int n1;
            var Int n2;
            var Int n3;
            n0 : data.Get(0);
            n1 : data.Get(1);
            n2 : data.Get(2);
            n3 : data.Get(3);

            var Bool ba;
            ba : (n0 = 11 & n1 = 57 & n2 = 98 & n3 = 149);

            inf (ba)
            {
                share Console.Out.Write("Network Host Case 1 Success\n");

                this.Stage : 2;

                data.Set(0, this.Stage);

                range.Count : 1;

                this.Stream.Write(data, range);
            }
            inf (~ba)
            {
                share Console.Out.Write("Network Host Case 1 Read Data Invalid\n");
                this.StatusCode : 4610;
                return false;
            }
        }

        inf (ka = 2)
        {
            var String kaa;
            kaa : this.StringComp.CreateData(data, null);

            var StringLess less;
            less : this.TextInfra.StringLessCreate();

            var Int kee;
            kee : less.Execute(kaa, "Fy Oi");

            var Bool bb;
            bb : kee = 0;

            share Console.Out.Write(this.ThreadState.AddClear().Add("Network Host Case 2 ").Add(this.ThreadState.StatusString(bb)).AddLine().AddResult());

            this.ThreadState.ExitNetwork(0);
            return true;
        }
        return true;
    }
}