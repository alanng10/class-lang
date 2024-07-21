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

    public virtual EncodeKind Utf8 { get { return __D_Utf8; } set { __D_Utf8 = value; } }
    protected EncodeKind __D_Utf8;
    public virtual EncodeKind Utf16 { get { return __D_Utf16; } set { __D_Utf16 = value; } }
    protected EncodeKind __D_Utf16;
    public virtual EncodeKind Utf16LE { get { return __D_Utf16LE; } set { __D_Utf16LE = value; } }
    protected EncodeKind __D_Utf16LE;
    public virtual EncodeKind Utf16BE { get { return __D_Utf16BE; } set { __D_Utf16BE = value; } }
    protected EncodeKind __D_Utf16BE;
    public virtual EncodeKind Utf32 { get { return __D_Utf32; } set { __D_Utf32 = value; } }
    protected EncodeKind __D_Utf32;
    public virtual EncodeKind Utf32LE { get { return __D_Utf32LE; } set { __D_Utf32LE = value; } }
    protected EncodeKind __D_Utf32LE;
    public virtual EncodeKind Utf32BE { get { return __D_Utf32BE; } set { __D_Utf32BE = value; } }
    protected EncodeKind __D_Utf32BE;
    public virtual EncodeKind Latin1 { get { return __D_Latin1; } set { __D_Latin1 = value; } }
    protected EncodeKind __D_Latin1;

    protected virtual EncodeKind AddItem(ulong o)
    {
        EncodeKind item;
        item = new EncodeKind();
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

    protected virtual int ArrayCount { get { return 8; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual EncodeKind Get(int index)
    {
        return (EncodeKind)this.Array.Get((object)index);
    }
}