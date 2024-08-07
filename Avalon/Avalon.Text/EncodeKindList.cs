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
        this.Utf16LE = this.AddItem(Extern.Stat_TextEncodeKindUtf16LE(stat));
        this.Utf16BE = this.AddItem(Extern.Stat_TextEncodeKindUtf16BE(stat));
        this.Utf32 = this.AddItem(Extern.Stat_TextEncodeKindUtf32(stat));
        this.Utf32LE = this.AddItem(Extern.Stat_TextEncodeKindUtf32LE(stat));
        this.Utf32BE = this.AddItem(Extern.Stat_TextEncodeKindUtf32BE(stat));
        this.Latin1 = this.AddItem(Extern.Stat_TextEncodeKindLatin1(stat));
        return true;
    }

    public virtual EncodeKind Utf8 { get; set; }
    public virtual EncodeKind Utf16 { get; set; }
    public virtual EncodeKind Utf16LE { get; set; }
    public virtual EncodeKind Utf16BE { get; set; }
    public virtual EncodeKind Utf32 { get; set; }
    public virtual EncodeKind Utf32LE { get; set; }
    public virtual EncodeKind Utf32BE { get; set; }
    public virtual EncodeKind Latin1 { get; set; }

    protected virtual EncodeKind AddItem(ulong o)
    {
        EncodeKind item;
        item = new EncodeKind();
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

    protected virtual int ArrayCount { get { return 8; } set { } }

    public virtual int Count { get; set; }
    
    protected virtual int Index { get; set; }

    public virtual EncodeKind Get(int index)
    {
        return (EncodeKind)this.Array.GetAt(index);
    }
}