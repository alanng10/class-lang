namespace Class.Infra;

public class LimitList : Any
{
    public static LimitList This { get; } = ShareCreate();

    private static LimitList ShareCreate()
    {
        LimitList share;
        share = new LimitList();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.StringValue = StringValue.This;
        this.InitArray();
        this.Count = this.Array.Count;
        this.Index = 0;

        this.StopSign = this.AddItem(".");
        this.PauseSign = this.AddItem(",");
        this.AreSign = this.AddItem(":");
        this.ExecuteSign = this.AddItem(";");
        this.SameSign = this.AddItem("=");
        this.AddSign = this.AddItem("+");
        this.SubSign = this.AddItem("-");
        this.MulSign = this.AddItem("*");
        this.DivSign = this.AddItem("/");
        this.AndSign = this.AddItem("&");
        this.OrnSign = this.AddItem("|");
        this.NotSign = this.AddItem("~");
        this.LessSign = this.AddItem("<");
        this.MoreSign = this.AddItem(">");
        this.BraceRoundLite = this.AddItem("(");
        this.BraceRoundRite = this.AddItem(")");
        this.BraceLite = this.AddItem("{");
        this.BraceRite = this.AddItem("}");
        return true;
    }

    public virtual Limit StopSign { get; set; }
    public virtual Limit PauseSign { get; set; }
    public virtual Limit AreSign { get; set; }
    public virtual Limit ExecuteSign { get; set; }
    public virtual Limit SameSign { get; set; }
    public virtual Limit AddSign { get; set; }
    public virtual Limit SubSign { get; set; }
    public virtual Limit MulSign { get; set; }
    public virtual Limit DivSign { get; set; }
    public virtual Limit AndSign { get; set; }
    public virtual Limit OrnSign { get; set; }
    public virtual Limit NotSign { get; set; }
    public virtual Limit LessSign { get; set; }
    public virtual Limit MoreSign { get; set; }
    public virtual Limit BraceRoundLite { get; set; }
    public virtual Limit BraceRoundRite { get; set; }
    public virtual Limit BraceLite { get; set; }
    public virtual Limit BraceRite { get; set; }

    protected virtual StringValue StringValue { get; set; }

    protected virtual Limit AddItem(string text)
    {
        String k;
        k = this.StringValue.Execute(text);

        Limit item;
        item = new Limit();
        item.Init();
        item.Index = this.Index;
        item.Text = k;
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

    protected virtual long ArrayCount { get { return 18; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual Limit Get(long index)
    {
        return (Limit)this.Array.GetAt(index);
    }
}