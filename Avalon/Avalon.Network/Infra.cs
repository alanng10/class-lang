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
        this.CaseList = CaseList.This;
        this.StatusList = StatusList.This;

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
        NetworkHostNewPeerMaide maideD;
        maideD = new NetworkHostNewPeerMaide(Host.InternNewPeer);
        this.HostNewPeerMaideAddress = new MaideAddress();
        this.HostNewPeerMaideAddress.Delegate = maideD;
        this.HostNewPeerMaideAddress.Init();
        return true;
    }

    public virtual MaideAddress NetworkStatusChangeMaideAddress { get; set; }
    public virtual MaideAddress NetworkCaseChangeMaideAddress { get; set; }
    public virtual MaideAddress NetworkReadyReadMaideAddress { get; set; }
    public virtual MaideAddress HostNewPeerMaideAddress { get; set; }
    protected virtual CaseList CaseList { get; set; }
    protected virtual StatusList StatusList { get; set; }

    public virtual Case CaseFromInternCase(long internCase)
    {
        ulong share;
        share = Extern.Infra_Share();
        ulong stat;
        stat = Extern.Share_Stat(share);

        ulong u;
        u = Extern.Stat_NetworkCaseConnected(stat);

        long k;
        k = (long)u;

        long ke;
        ke = 0;

        if (internCase == k)
        {
            ke = 1;
        }

        Case a;
        a = this.CaseList.Get(ke);

        return a;
    }
}