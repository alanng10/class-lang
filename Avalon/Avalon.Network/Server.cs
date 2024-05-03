namespace Avalon.Network;

public class Server : Any
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
        Extern.NetworkServer_Final(this.Intern);
        Extern.NetworkServer_Delete(this.Intern);

        this.InternInfra.StateDelete(this.InternNewPeerState);

        this.InternHandle.Final();
        return true;
    }

    public virtual Address Address { get; set; }
    public virtual State NewPeerState { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    private Infra NetworkInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternNewPeerState { get; set; }
    private Handle InternHandle { get; set; }

    public virtual bool Listen()
    {
        ulong addressU;
        addressU = this.Address.Intern;

        Extern.NetworkServer_PortSet(this.Intern, addressU);
        
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

    public virtual bool IsListen
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

    public virtual Network NextPendingPeer()
    {
        ulong networkU;
        networkU = Extern.NetworkServer_NextPendingPeer(this.Intern);

        Network a;
        a = new Network();
        a.SetIntern = networkU;
        a.Init();
        return a;
    }

    public virtual bool ClosePeer(Network network)
    {
        ulong u;
        u = network.SetIntern;

        network.Final();

        Extern.NetworkServer_ClosePeer(this.Intern, u);
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

        Server a;
        a = (Server)ao;
        a.ExecuteNewPeerState();

        return 1;
    }
}