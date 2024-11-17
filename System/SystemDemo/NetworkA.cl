class NetworkA : Network
{
    maide prusate Bool Init()
    {
        base.Init();
        this.NetworkStatusList : share NetworkStatusList;
        this.NetworkCaseList : share NetworkCaseList;

        this.Data : new Data;
        this.Data.Count : 1;
        this.Data.Init();

        this.Range : new Range;
        this.Range.Init();
        return true;
    }

    field prusate ThreadNetworkState ThreadNetworkState { get { return data; } set { data : value; } }
    field precate NetworkStatusList NetworkStatusList { get { return data; } set { data : value; } }
    field precate NetworkCaseList NetworkCaseList { get { return data; } set { data : value; } }
    field precate Data Data { get { return data; } set { data : value; } }
    field precate Range Range { get { return data; } set { data : value; } }
    field precate Int StatusCode { get { return data; } set { data : value; } }

    maide prusate Bool CaseEvent()
    {
        inf (this.Case = this.NetworkCaseList.Connected)
        {
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
        inf (~(this.Status == this.NetworkStatusList.NoError))
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

        inf (~(k < 1))
        {
            var Data data;
            data : this.Data;

            var Range range;
            range : this.Range;
            range.Index : 0;
            range.Count : 1;

            this.Stream.Read(data, range);

            var Int n;
            n : data.Get(0);

            var Bool b;
            b : n = 53;

            inf (b)
            {
                share Console.Out.Write("Network Success\n");

                this.ThreadState.ExitNetwork(0);
                return true;
            }

            inf (!b)
            {
                this.StatusCode : 4100;
                return false;
            }
        }
    }
}