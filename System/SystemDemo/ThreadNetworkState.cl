class ThreadNetworkState : StateA
{
    maide prusate Bool Init()
    {
        base.Init();
        this.NetworkStatusList : share NetworkStatusList;
        this.NetworkCaseList : share NetworkCaseList;

        this.DeA : new DeA;
        this.DeA.Init();
        return true;
    }

    field precate NetworkStatusList NetworkStatusList { get { return data; } set { data : value; } }
    field precate NetworkCaseList NetworkCaseList { get { return data; } set { data : value; } }
    field precate NetworkA Network { get { return data; } set { data : value; } }
    field precate DeA DeA { get { return data; } set { data : value; } }

    maide prusate Bool Execute()
    {
        var String hostName;
        hostName : "localhost";
        var Int hostPort;
        hostPort : 59843;

        var NetworkA network;
        network : new NetworkA;
        network.Init();

        network.ThreadState : this;

        network.HostName : hostName;
        network.HostPort : hostPort;

        this.Network : network;

        network.Open();

        var ThreadThis varThis;
        varThis : new ThreadThis;
        varThis.Init();

        var Int ka;
        ka : varThis.Thread.ExecuteMain();

        network.Final();

        this.Network : null;

        var String k;

        var Bool b;
        b : (ka = 0);
        inf (b)
        {
            k : "Success";
        }
        inf (~b)
        {
            k : "Fail";
        }

        share Console.Out.Write(this.AddClear().Add("Network ").Add(k).Add(", code: ").Add(this.StringInt(ka)).AddLine().AddResult()));
        return true;
    }
}