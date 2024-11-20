namespace Avalon.Network;

public class Host : Any
{
    private bool PrivateNewPeer()
    {
        this.NewPeer();
        return true;
    }

    public override bool Init()
    {
        base.Init();
        this.InternIntern = global::Avalon.Infra.Intern.This;
        this.InternInfra = InternInfra.This;
        this.NetworkInfra = Infra.This;
        this.InternHandle = new Handle();
        this.InternHandle.Any = this;
        this.InternHandle.Init();

        MaideAddress ka;
        ka = this.NetworkInfra.HostNewPeerMaideAddress;
        ulong arg;
        arg = this.InternHandle.ULong();
        this.InternNewPeerState = this.InternInfra.StateCreate(ka, arg);

        this.InternPort = Extern.NetworkPort_New();
        Extern.NetworkPort_Init(this.InternPort);

        this.Intern = Extern.NetworkHost_New();
        Extern.NetworkHost_Init(this.Intern);
        Extern.NetworkHost_NewPeerStateSet(this.Intern, this.InternNewPeerState);
        Extern.NetworkHost_PortSet(this.Intern, this.InternPort);
        return true;
    }

    public virtual bool Final()
    {
        Extern.NetworkHost_Final(this.Intern);
        Extern.NetworkHost_Delete(this.Intern);

        Extern.NetworkPort_Final(this.InternPort);
        Extern.NetworkPort_Delete(this.InternPort);

        this.InternInfra.StateDelete(this.InternNewPeerState);

        this.InternHandle.Final();
        return true;
    }

    public virtual Port Port { get; set; }
    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private Infra NetworkInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternPort { get; set; }
    private ulong InternNewPeerState { get; set; }
    private Handle InternHandle { get; set; }

    public virtual bool Open()
    {
        this.InternPortSet();
        
        ulong k;
        k = Extern.NetworkHost_Open(this.Intern);

        bool a;
        a = !(k == 0);
        return a;
    }

    public virtual bool Close()
    {
        Extern.NetworkHost_Close(this.Intern);
        return true;
    }

    public virtual Network OpenPeer()
    {
        ulong k;
        k = Extern.NetworkHost_OpenPeer(this.Intern);

        Network a;
        a = this.CreatePeer(k);
        return a;
    }

    public virtual bool ClosePeer(Network a)
    {
        ulong k;
        k = a.HostPeer;

        this.FinalPeer(a);

        Extern.NetworkHost_ClosePeer(this.Intern, k);
        return true;
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

    private bool InternPortSet()
    {
        ulong kindU;
        kindU = this.Port.Kind.Intern;
        ulong valueAU;
        ulong valueBU;
        ulong valueCU;
        ulong hostU;
        valueAU = (ulong)this.Port.ValueA;
        valueBU = (ulong)this.Port.ValueB;
        valueCU = (ulong)this.Port.ValueC;
        hostU = (ulong)this.Port.Host;

        Extern.NetworkPort_KindSet(this.InternPort, kindU);
        Extern.NetworkPort_ValueASet(this.InternPort, valueAU);
        Extern.NetworkPort_ValueBSet(this.InternPort, valueBU);
        Extern.NetworkPort_ValueCSet(this.InternPort, valueCU);
        Extern.NetworkPort_HostSet(this.InternPort, hostU);
        Extern.NetworkPort_Set(this.InternPort);
        return true;
    }

    public virtual bool NewPeer()
    {
        return false;
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