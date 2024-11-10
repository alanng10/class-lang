class Host : Any
{
    maide private Bool PrivateNewPeer()
    {
        this.NewPeer();
        return true;
    }

    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;

        var Int ka;
        ka : this.InternIntern.StateNetworkHostNewPeer();
        var Int arg;
        arg : this.InternIntern.Memory(this);
        this.InternNewPeerState : this.InternInfra.StateCreate(ka, arg);

        var Extern extern;
        extern : this.Extern;

        this.InternPort : extern.NetworkPort_New();
        extern.NetworkPort_Init(this.InternPort);

        this.Intern : extern.NetworkHost_New();
        extern.NetworkHost_Init(this.Intern);
        extern.NetworkHost_NewPeerStateSet(this.Intern, this.InternNewPeerState);
        extern.NetworkHost_PortSet(this.Intern, this.InternPort);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.NetworkHost_Final(this.Intern);
        extern.NetworkHost_Delete(this.Intern);

        extern.NetworkPort_Final(this.InternPort);
        extern.NetworkPort_Delete(this.InternPort);

        this.InternInfra.StateDelete(this.InternNewPeerState);
        return true;
    }

    field prusate Port Port { get { return data; } set { data : value; } }
    field private Intern InternIntern { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    field private Int InternPort { get { return data; } set { data : value; } }
    field private Int InternNewPeerState { get { return data; } set { data : value; } }

    maide prusate Bool Open()
    {
        this.InternPortSet();

        var Int k;
        k : this.Extern.NetworkHost_Open(this.Intern);

        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool Close()
    {
        this.Extern.NetworkHost_Close(this.Intern);
        return true;
    }

    maide prusate Network OpenPeer()
    {
        var Int k;
        k : this.Extern.NetworkHost_OpenPeer(this.Intern);

        var Network a;
        a : this.CreatePeer(k);
        return a;
    }

    maide prusate Bool ClosePeer(var Network network)
    {
        var Int k;
        k : network.HostPeer;

        this.FinalPeer(network);

        this.Extern.NetworkHost_ClosePeer(this.Intern, k);
        return true;
    }

    maide precate Network CreatePeer(var Int peer)
    {
        var Network a;
        a : new Network;
        a.HostPeer : peer;
        a.Init();
        return a;
    }
}