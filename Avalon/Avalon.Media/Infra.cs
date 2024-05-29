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
        maideA = new VideoOutFrameMaide(VideoOut.InternFrame);
        this.VideoOutFrameMaideAddress = new MaideAddress();
        this.VideoOutFrameMaideAddress.Delegate = maideA;
        this.VideoOutFrameMaideAddress.Init();
        return true;
    }

    internal virtual MaideAddress VideoOutFrameMaideAddress { get; set; }
}