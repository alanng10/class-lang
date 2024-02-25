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

    public virtual TextAlign LeftUp { get; set; }
    public virtual TextAlign LeftDown { get; set; }
    public virtual TextAlign LeftCenter { get; set; }
    public virtual TextAlign RightUp { get; set; }
    public virtual TextAlign RightDown { get; set; }
    public virtual TextAlign RightCenter { get; set; }
    public virtual TextAlign CenterUp { get; set; }
    public virtual TextAlign CenterDown { get; set; }
    public virtual TextAlign CenterCenter { get; set; }

    protected virtual TextAlign AddItem(ulong horzAlign, ulong vertAlign)
    {
        TextAlign item;
        item = new TextAlign();
        item.Init();
        item.Index = this.Index;
        item.Intern = horzAlign | vertAlign;
        this.Array.Set(item.Index, item);
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

    protected virtual int ArrayCount
    { 
        get
        {
            return 9;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual TextAlign Get(int index)
    {
        return (TextAlign)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}