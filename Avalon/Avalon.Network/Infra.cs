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





        NetworkCaseChangedMaide maideA;

        maideA = new NetworkCaseChangedMaide(Network.InternCaseChanged);



        this.NetworkCaseChangedMaideAddress = new MaideAddress();


        this.NetworkCaseChangedMaideAddress.Delegate = maideA;


        this.NetworkCaseChangedMaideAddress.Init();





        NetworkReadyReadMaide maideB;

        maideB = new NetworkReadyReadMaide(Network.InternReadyRead);



        this.NetworkReadyReadMaideAddress = new MaideAddress();


        this.NetworkReadyReadMaideAddress.Delegate = maideB;


        this.NetworkReadyReadMaideAddress.Init();






        NetworkServerNewPeerMaide maideC;

        maideC = new NetworkServerNewPeerMaide(Server.InternNewPeer);



        this.NetworkServerNewPeerMaideAddress = new MaideAddress();


        this.NetworkServerNewPeerMaideAddress.Delegate = maideC;


        this.NetworkServerNewPeerMaideAddress.Init();





        return true;
    }





    public virtual MaideAddress NetworkCaseChangedMaideAddress { get; set; }



    public virtual MaideAddress NetworkReadyReadMaideAddress { get; set; }



    public virtual MaideAddress NetworkServerNewPeerMaideAddress { get; set; }
}