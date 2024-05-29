namespace Avalon.Media;

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
        VideoOutFrameMaide maideA;
        maideA = new VideoOutFrameMaide(Out.InternFrame);
        this.OutFrameMaideAddress = new MaideAddress();
        this.OutFrameMaideAddress.Delegate = maideA;
        this.OutFrameMaideAddress.Init();
        return true;
    }

    internal virtual MaideAddress OutFrameMaideAddress { get; set; }
}