namespace Avalon.Text;

public class CodeKindList : Any
{
    public static CodeKindList This { get; } = ShareCreate();

    private static CodeKindList ShareCreate()
    {
        CodeKindList share;
        share = new CodeKindList();
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

    public virtual CodeKind Utf8 { get; set; }
    public virtual CodeKind Utf16 { get; set; }
    public virtual CodeKind Utf32 { get; set; }

    protected virtual CodeKind AddItem(ulong o)
    {
        long index;
        index = this.Index;

        CodeKind item;
        item = new CodeKind();
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

    public virtual CodeKind Get(long index)
    {
        return (CodeKind)this.Array.GetAt(index);
    }
}