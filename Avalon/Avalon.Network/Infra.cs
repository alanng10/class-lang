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
        NetworkStatusChangeMaide maideA;
        maideA = new NetworkStatusChangeMaide(Network.InternStatusEvent);
        this.NetworkStatusEventMaideAddress = new MaideAddress();
        this.NetworkStatusEventMaideAddress.Delegate = maideA;
        this.NetworkStatusEventMaideAddress.Init();
        NetworkCaseChangeMaide maideB;
        maideB = new NetworkCaseChangeMaide(Network.InternCaseEvent);
        this.NetworkCaseEventMaideAddress = new MaideAddress();
        this.NetworkCaseEventMaideAddress.Delegate = maideB;
        this.NetworkCaseEventMaideAddress.Init();
        NetworkReadyReadMaide maideC;
        maideC = new NetworkReadyReadMaide(Network.InternDataEvent);
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