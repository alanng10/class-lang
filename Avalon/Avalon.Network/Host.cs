namespace Avalon.Network;

public class Host : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
        this.NetworkInfra = Infra.This;
        this.InternHandle = new Handle();
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        this.InternPort = Extern.NetworkPort_New();
        Extern.NetworkPort_Init(this.InternPort);

        MaideAddress oa;
        oa = this.NetworkInfra.ServerNewPeerMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();
        this.InternNewPeerState = this.InternInfra.StateCreate(oa, arg);

        this.Intern = Extern.NetworkServer_New();
        Extern.NetworkServer_Init(this.Intern);
        Extern.NetworkServer_NewPeerStateSet(this.Intern, this.InternNewPeerState);
        return true;
    }

    public virtual bool Final()
    {
        Extern.NetworkServer_NewPeerStateSet(this.Intern, 0);

        Extern.NetworkServer_Final(this.Intern);
        Extern.NetworkServer_Delete(this.Intern);

        this.InternInfra.StateDelete(this.InternNewPeerState);

        Extern.NetworkPort_Final(this.InternPort);
        Extern.NetworkPort_Delete(this.InternPort);

        this.InternHandle.Final();
        return true;
    }

    public virtual Port Port { get; set; }
    public virtual State NewPeerState { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private Infra NetworkInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternNewPeerState { get; set; }
    private ulong InternPort { get; set; }
    private Handle InternHandle { get; set; }

    public virtual bool Open()
    {
        this.InternPortSet();

        Extern.NetworkServer_PortSet(this.Intern, this.InternPort);
        
        ulong u;
        u = Extern.NetworkServer_Listen(this.Intern);
        bool a;
        a = (!(u == 0));
        return a;
    }

    public virtual bool Close()
    {
        Extern.NetworkServer_Close(this.Intern);
        return true;
    }

    public virtual bool IsOpen
    {
        get
        {
            ulong u;
            u = Extern.NetworkServer_IsListen(this.Intern);
            bool a;
            a = (!(u == 0));
            return a;
        }
        set
        {
        }
    }

    public virtual Network OpenPeer()
    {
        ulong networkU;
        networkU = Extern.NetworkServer_NextPendingPeer(this.Intern);

        Network a;
        a = this.CreatePeer(networkU);
        return a;
    }

    protected virtual Network CreatePeer(ulong hostPeer)
    {
        Network a;
        a = new Network();
        a.HostPeer = hostPeer;
        a.Init();
        return a;
    }

    protected virtual bool FinalPeer(Network a)
    {
        a.Final();
        return true;
    }

    public virtual bool ClosePeer(Network network)
    {
        ulong u;
        u = network.HostPeer;

        this.FinalPeer(network);

        Extern.NetworkServer_ClosePeer(this.Intern, u);
        return true;
    }

    private bool InternPortSet()
    {
        Port aa;
        aa = this.Port;

        ulong kindU;
        kindU = aa.Kind.Intern;
        ulong valueAU;
        ulong valueBU;
        ulong valueCU;
        ulong serverU;
        valueAU = (ulong)aa.ValueA;
        valueBU = (ulong)aa.ValueB;
        valueCU = (ulong)aa.ValueC;
        serverU = (ulong)aa.Server;

        ulong u;
        u = this.InternPort;
        Extern.NetworkPort_KindSet(u, kindU);
        Extern.NetworkPort_ValueASet(u, valueAU);
        Extern.NetworkPort_ValueBSet(u, valueBU);
        Extern.NetworkPort_ValueCSet(u, valueCU);
        Extern.NetworkPort_ServerSet(u, serverU);
        Extern.NetworkPort_Set(u);
        return true;
    }

    private bool ExecuteNewPeerState()
    {
        if (!(this.NewPeerState == null))
        {
            this.NewPeerState.Execute();
        }
        return true;
    }

    internal static ulong InternNewPeer(ulong networkServer, ulong arg)
    {
        InternIntern internIntern;
        internIntern = InternIntern.This;

        object ao;
        ao = internIntern.HandleTarget(arg);

        Host a;
        a = (Host)ao;
        a.ExecuteNewPeerState();

        return 1;
    }
}