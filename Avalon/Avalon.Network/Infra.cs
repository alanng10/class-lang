namespace Avalon.Network;

class Infra : Any
{
    public static Infra This { get; } = ShareCreate();

    private static Infra ShareCreate()
    {
        Infra share;
        share = new Infra();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        NetworkStatusEventMaide maideA;
        maideA = new NetworkStatusEventMaide(Network.InternStatusEvent);
        this.NetworkStatusEventMaideAddress = new MaideAddress();
        this.NetworkStatusEventMaideAddress.Delegate = maideA;
        this.NetworkStatusEventMaideAddress.Init();
        NetworkCaseEventMaide maideB;
        maideB = new NetworkCaseEventMaide(Network.InternCaseEvent);
        this.NetworkCaseEventMaideAddress = new MaideAddress();
        this.NetworkCaseEventMaideAddress.Delegate = maideB;
        this.NetworkCaseEventMaideAddress.Init();
        NetworkDataEventMaide maideC;
        maideC = new NetworkDataEventMaide(Network.InternDataEvent);
        this.NetworkDataEventMaideAddress = new MaideAddress();
        this.NetworkDataEventMaideAddress.Delegate = maideC;
        this.NetworkDataEventMaideAddress.Init();
        NetworkHostNewPeerMaide maideD;
        maideD = new NetworkHostNewPeerMaide(Host.InternNewPeer);
        this.HostNewPeerMaideAddress = new MaideAddress();
        this.HostNewPeerMaideAddress.Delegate = maideD;
        this.HostNewPeerMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress NetworkStatusEventMaideAddress { get; set; }
    public virtual MaideAddress NetworkCaseEventMaideAddress { get; set; }
    public virtual MaideAddress NetworkDataEventMaideAddress { get; set; }
    public virtual MaideAddress HostNewPeerMaideAddress { get; set; }
}