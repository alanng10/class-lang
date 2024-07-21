namespace Avalon.Draw;

public class ImageFormatList : Any
{
    public static ImageFormatList This { get; } = ShareCreate();

    private static ImageFormatList ShareCreate()
    {
        ImageFormatList share;
        share = new ImageFormatList();
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

        this.Bmp = this.AddItem(Extern.Stat_ImageFormatBmp(stat));
        this.Jpg = this.AddItem(Extern.Stat_ImageFormatJpg(stat));
        this.Png = this.AddItem(Extern.Stat_ImageFormatPng(stat));
        return true;
    }

    public virtual ImageFormat Bmp { get { return __D_Bmp; } set { __D_Bmp = value; } }
    protected ImageFormat __D_Bmp;
    public virtual ImageFormat Jpg { get { return __D_Jpg; } set { __D_Jpg = value; } }
    protected ImageFormat __D_Jpg;
    public virtual ImageFormat Png { get { return __D_Png; } set { __D_Png = value; } }
    protected ImageFormat __D_Png;

    protected virtual ImageFormat AddItem(ulong o)
    {
        ImageFormat item;
        item = new ImageFormat();
        item.Init();
        item.Index = this.Index;
        item.Intern = o;
        this.Array.Set((object)item.Index, item);
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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 3; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual ImageFormat Get(int index)
    {
        return (ImageFormat)this.Array.Get((object)index);
    }
}