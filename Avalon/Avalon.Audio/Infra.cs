namespace Avalon.Audio;

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

        this.PixelByteCount = 2;
        return true;
    }

    public virtual long PixelByteCount { get; set; }
}