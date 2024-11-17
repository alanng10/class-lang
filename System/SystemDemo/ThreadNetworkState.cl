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

        this.Network = null;

        string k;
        k = null;
        bool b;
        b = (o == 0);
        if (b)
        {
            k = "Success";
        }
        if (!b)
        {
            k = "Fail";
        }

        Console.This.Out.Write(this.S("Network " + k + ", code: " + o + "\n"));
        return true;
    }
}