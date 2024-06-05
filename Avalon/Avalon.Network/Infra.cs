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
        maideA = new NetworkStatusChangeMaide(Network.InternStatusChange);
        this.NetworkStatusChangeMaideAddress = new MaideAddress();
        this.NetworkStatusChangeMaideAddress.Delegate = maideA;
        this.NetworkStatusChangeMaideAddress.Init();
        NetworkCaseChangeMaide maideB;
        maideB = new NetworkCaseChangeMaide(Network.InternCaseChange);
        this.NetworkCaseChangeMaideAddress = new MaideAddress();
        this.NetworkCaseChangeMaideAddress.Delegate = maideB;
        this.NetworkCaseChangeMaideAddress.Init();
        NetworkReadyReadMaide maideC;
        maideC = new NetworkReadyReadMaide(Network.InternReadyRead);
        this.NetworkReadyReadMaideAddress = new MaideAddress();
        this.NetworkReadyReadMaideAddress.Delegate = maideC;
        this.NetworkReadyReadMaideAddress.Init();
        NetworkServerNewPeerMaide maideD;
        maideD = new NetworkServerNewPeerMaide(Server.InternNewPeer);
        this.ServerNewPeerMaideAddress = new MaideAddress();
        this.ServerNewPeerMaideAddress.Delegate = maideD;
        this.ServerNewPeerMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress NetworkStatusChangeMaideAddress { get; set; }
    public virtual MaideAddress NetworkCaseChangeMaideAddress { get; set; }
    public virtual MaideAddress NetworkReadyReadMaideAddress { get; set; }
    public virtual MaideAddress ServerNewPeerMaideAddress { get; set; }
}