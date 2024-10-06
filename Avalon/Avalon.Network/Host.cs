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
        oa = this.NetworkInfra.HostNewPeerMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();
        this.InternNewPeerState = this.InternInfra.StateCreate(oa, arg);

        this.Intern = Extern.NetworkHost_New();
        Extern.NetworkHost_Init(this.Intern);
        Extern.NetworkHost_NewPeerStateSet(this.Intern, this.InternNewPeerState);
        return true;
    }

    public virtual bool Final()
    {
        Extern.NetworkHost_NewPeerStateSet(this.Intern, 0);

        Extern.NetworkHost_Final(this.Intern);
        Extern.NetworkHost_Delete(this.Intern);

        this.InternInfra.StateDelete(this.InternNewPeerState);

        Extern.NetworkPort_Final(this.InternPort);
        Extern.NetworkPort_Delete(this.InternPort);

        this.InternHandle.Final();
        return true;
    }

    public virtual Port Port { get; set; }
    public virtual bool IsOpen { get; set; }
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

        Extern.NetworkHost_PortSet(this.Intern, this.InternPort);
        
        ulong u;
        u = Extern.NetworkHost_Open(this.Intern);

        bool k;
        k = (!(u == 0));

        if (k)
        {
            this.IsOpen = true;
        }

        bool a;
        a = k;
        return a;
    }

    public virtual bool Close()
    {
        this.IsOpen = false;

        Extern.NetworkHost_Close(this.Intern);
        return true;
    }

    public virtual Network OpenPeer()
    {
        ulong networkU;
        networkU = Extern.NetworkHost_OpenPeer(this.Intern);

        Network a;
        a = this.CreatePeer(networkU);
        return a;
    }

    protected virtual Network CreatePeer(ulong peer)
    {
        Network a;
        a = new Network();
        a.HostPeer = peer;
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

        Extern.NetworkHost_ClosePeer(this.Intern, u);
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
        ulong hostU;
        valueAU = (ulong)aa.ValueA;
        valueBU = (ulong)aa.ValueB;
        valueCU = (ulong)aa.ValueC;
        hostU = (ulong)aa.Host;

        ulong u;
        u = this.InternPort;
        Extern.NetworkPort_KindSet(u, kindU);
        Extern.NetworkPort_ValueASet(u, valueAU);
        Extern.NetworkPort_ValueBSet(u, valueBU);
        Extern.NetworkPort_ValueCSet(u, valueCU);
        Extern.NetworkPort_HostSet(u, hostU);
        Extern.NetworkPort_Set(u);
        return true;
    }

    private bool PrivateNewPeer()
    {
        this.PeerEvent();
        return true;
    }

    public virtual bool PeerEvent()
    {
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
        a.PrivateNewPeer();

        return 1;
    }
}