namespace Avalon.Video;




public class Infra : Any
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





        this.PixelByteCount = 4;




        VideoOutFrameMaide maideA;

        maideA = new VideoOutFrameMaide(Out.InternFrame);



        this.OutFrameMaideAddress = new MaideAddress();


        this.OutFrameMaideAddress.Delegate = maideA;


        this.OutFrameMaideAddress.Init();




        return true;
    }





    public virtual int PixelByteCount { get; set; }





    internal virtual MaideAddress OutFrameMaideAddress { get; set; }
}