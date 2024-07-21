namespace Avalon.Draw;

public class TextAlignList : Any
{
    public static TextAlignList This { get; } = ShareCreate();

    private static TextAlignList ShareCreate()
    {
        TextAlignList share;
        share = new TextAlignList();
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

        this.LeftUp = this.AddItem(Extern.Stat_TextAlignLeft(stat), Extern.Stat_TextAlignTop(stat));
        this.LeftDown = this.AddItem(Extern.Stat_TextAlignLeft(stat), Extern.Stat_TextAlignBottom(stat));
        this.LeftCenter = this.AddItem(Extern.Stat_TextAlignLeft(stat), Extern.Stat_TextAlignVCenter(stat));
        this.RightUp = this.AddItem(Extern.Stat_TextAlignRight(stat), Extern.Stat_TextAlignTop(stat));
        this.RightDown = this.AddItem(Extern.Stat_TextAlignRight(stat), Extern.Stat_TextAlignBottom(stat));
        this.RightCenter = this.AddItem(Extern.Stat_TextAlignRight(stat), Extern.Stat_TextAlignVCenter(stat));
        this.CenterUp = this.AddItem(Extern.Stat_TextAlignHCenter(stat), Extern.Stat_TextAlignTop(stat));
        this.CenterDown = this.AddItem(Extern.Stat_TextAlignHCenter(stat), Extern.Stat_TextAlignBottom(stat));
        this.CenterCenter = this.AddItem(Extern.Stat_TextAlignHCenter(stat), Extern.Stat_TextAlignVCenter(stat));
        return true;
    }

    public virtual TextAlign LeftUp { get { return __D_LeftUp; } set { __D_LeftUp = value; } }
    protected TextAlign __D_LeftUp;
    public virtual TextAlign LeftDown { get { return __D_LeftDown; } set { __D_LeftDown = value; } }
    protected TextAlign __D_LeftDown;
    public virtual TextAlign LeftCenter { get { return __D_LeftCenter; } set { __D_LeftCenter = value; } }
    protected TextAlign __D_LeftCenter;
    public virtual TextAlign RightUp { get { return __D_RightUp; } set { __D_RightUp = value; } }
    protected TextAlign __D_RightUp;
    public virtual TextAlign RightDown { get { return __D_RightDown; } set { __D_RightDown = value; } }
    protected TextAlign __D_RightDown;
    public virtual TextAlign RightCenter { get { return __D_RightCenter; } set { __D_RightCenter = value; } }
    protected TextAlign __D_RightCenter;
    public virtual TextAlign CenterUp { get { return __D_CenterUp; } set { __D_CenterUp = value; } }
    protected TextAlign __D_CenterUp;
    public virtual TextAlign CenterDown { get { return __D_CenterDown; } set { __D_CenterDown = value; } }
    protected TextAlign __D_CenterDown;
    public virtual TextAlign CenterCenter { get { return __D_CenterCenter; } set { __D_CenterCenter = value; } }
    protected TextAlign __D_CenterCenter;

    protected virtual TextAlign AddItem(ulong horzAlign, ulong vertAlign)
    {
        TextAlign item;
        item = new TextAlign();
        item.Init();
        item.Index = this.Index;
        item.Intern = horzAlign | vertAlign;
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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 9; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual TextAlign Get(int index)
    {
        return (TextAlign)this.Array.GetAt(index);
    }
}