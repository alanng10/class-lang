namespace Avalon.Text;

public class EncodeKindList : Any
{
    public static EncodeKindList This { get; } = ShareCreate();

    private static EncodeKindList ShareCreate()
    {
        EncodeKindList share;
        share = new EncodeKindList();
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

        this.Utf8 = this.AddItem(Extern.Stat_TextEncodeKindUtf8(stat));
        this.Utf16 = this.AddItem(Extern.Stat_TextEncodeKindUtf16(stat));
        this.Utf32 = this.AddItem(Extern.Stat_TextEncodeKindUtf32(stat));
        return true;
    }

    public virtual EncodeKind Utf8 { get; set; }
    public virtual EncodeKind Utf16 { get; set; }
    public virtual EncodeKind Utf32 { get; set; }

    protected virtual EncodeKind AddItem(ulong o)
    {
        long index;
        index = this.Index;

        EncodeKind item;
        item = new EncodeKind();
        item.Init();
        item.Index = index;
        item.Intern = o;
        this.Array.SetAt(index, item);
        this.Index = index + 1;
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

    public virtual EncodeKind Get(long index)
    {
        return (EncodeKind)this.Array.GetAt(index);
    }
}