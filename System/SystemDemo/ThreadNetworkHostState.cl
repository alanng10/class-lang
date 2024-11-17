class ThreadNetworkHostState : StateA
{
    field prusate Network Peer { get { return data; } set { data : value; } }
    field prusate NetworkHost Host { get { return data; } set { data : value; } }

    maide prusate Bool Execute()
    {
        var NetworkPortKindList portKindList;
        portKindList : share NetworkPortKindList;

        var NetworkPort port;
        port : new NetworkPort;
        port.Init();
        port.Kind : portKindList.LocalHost;
        port.Host : 59843;

        var NetworkHostA host;
        host : new NetworkHostA;
        host.Init();
        host.ThreadState : this;
        
        this.Host : host;

        host.Port : port;

        this.Host.Open();

        var ThreadThis varThis;
        varThis : new ThreadThis;
        varThis.Init();

        var Int ka;
        ka : varThis.Thread.ExecuteMain();

        this.Host.Final();

        this.Peer : null;
        this.Host : null;

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

        share Console.Out.Write(this.AddClear().Add("Network Host ").Add(k).Add(", status: ").Add(this.StringInt(ka)).AddLine().AddResult());
        return true;
    }

    maide prusate Bool ExitNetwork(var Int status)
    {
        this.Host.ClosePeer(this.Peer);

        this.Host.Close();

        var ThreadThis varThis;
        varThis : new ThreadThis;
        varThis.Init();

        varThis.Thread.Exit(status);
        return true;
    }
}