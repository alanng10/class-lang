namespace Avalon.Draw;

public class ImageBinaryList : Any
{
    public static ImageBinaryList This { get; } = ShareCreate();

    private static ImageBinaryList ShareCreate()
    {
        ImageBinaryList share;
        share = new ImageBinaryList();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count = this.Array.Count;
        this.Index = 0;

        ulong share;
        share = Extern.Infra_Share();
        ulong stat;
        stat = Extern.Share_Stat(share);

        this.Bmp = this.AddItem(Extern.Stat_ImageBinaryBmp(stat));
        this.Jpg = this.AddItem(Extern.Stat_ImageBinaryJpg(stat));
        this.Png = this.AddItem(Extern.Stat_ImageBinaryPng(stat));
        return true;
    }

    public virtual ImageBinary Bmp { get; set; }
    public virtual ImageBinary Jpg { get; set; }
    public virtual ImageBinary Png { get; set; }

    protected virtual ImageBinary AddItem(ulong o)
    {
        ImageBinary item;
        item = new ImageBinary();
        item.Init();
        item.Index = this.Index;
        item.Intern = o;
        this.Array.SetAt(item.Index, item);
        this.Index = this.Index + 1;
        return item;
    }

    protected virtual bool InitArray()
    {
        this.Array = new Array();
        this.Array.Count = this.ArrayCount;
        this.Array.Init();
        return true;
    }

    protected virtual Array Array { get; set; }

    protected virtual long ArrayCount { get { return 3; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual ImageBinary Get(long index)
    {
        return (ImageBinary)this.Array.GetAt(index);
    }
}