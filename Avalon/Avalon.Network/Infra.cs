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
        NetworkCaseChangeMaide maideA;
        maideA = new NetworkCaseChangeMaide(Network.InternCaseChange);
        this.NetworkCaseChangeMaideAddress = new MaideAddress();
        this.NetworkCaseChangeMaideAddress.Delegate = maideA;
        this.NetworkCaseChangeMaideAddress.Init();
        NetworkReadyReadMaide maideB;
        maideB = new NetworkReadyReadMaide(Network.InternReadyRead);
        this.NetworkReadyReadMaideAddress = new MaideAddress();
        this.NetworkReadyReadMaideAddress.Delegate = maideB;
        this.NetworkReadyReadMaideAddress.Init();
        NetworkServerNewPeerMaide maideC;
        maideC = new NetworkServerNewPeerMaide(Server.InternNewPeer);
        this.ServerNewPeerMaideAddress = new MaideAddress();
        this.ServerNewPeerMaideAddress.Delegate = maideC;
        this.ServerNewPeerMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress NetworkCaseChangeMaideAddress { get; set; }
    public virtual MaideAddress NetworkReadyReadMaideAddress { get; set; }
    public virtual MaideAddress ServerNewPeerMaideAddress { get; set; }
}