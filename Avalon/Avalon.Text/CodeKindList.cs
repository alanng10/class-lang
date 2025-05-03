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

        this.Utf8 = this.AddItem(SystemTextCode.UTF8);
        this.Utf16 = this.AddItem(SystemTextCode.Unicode);
        this.Utf32 = this.AddItem(SystemTextCode.UTF32);
        return true;
    }

    public virtual CodeKind Utf8 { get; set; }
    public virtual CodeKind Utf16 { get; set; }
    public virtual CodeKind Utf32 { get; set; }

    protected virtual CodeKind AddItem(SystemTextCode intern)
    {
        CodeKind item;
        item = new CodeKind();
        item.Init();
        item.Index = this.Index;
        item.Intern = intern;
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

    public virtual CodeKind Get(long index)
    {
        return this.Array.GetAt(index) as CodeKind;
    }
}