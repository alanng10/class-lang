namespace Saber.Infra;

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

        this.Stop = this.AddItem(".");
        this.Pause = this.AddItem(",");
        this.Are = this.AddItem(":");
        this.Execute = this.AddItem(";");
        this.Same = this.AddItem("=");
        this.Add = this.AddItem("+");
        this.Sub = this.AddItem("-");
        this.Mul = this.AddItem("*");
        this.Div = this.AddItem("/");
        this.And = this.AddItem("&");
        this.Orn = this.AddItem("|");
        this.Not = this.AddItem("~");
        this.Less = this.AddItem("<");
        this.More = this.AddItem(">");
        this.BraceRoundLite = this.AddItem("(");
        this.BraceRoundRite = this.AddItem(")");
        this.BraceCurveLite = this.AddItem("{");
        this.BraceCurveRite = this.AddItem("}");
        return true;
    }

    public virtual Limit Stop { get; set; }
    public virtual Limit Pause { get; set; }
    public virtual Limit Are { get; set; }
    public virtual Limit Execute { get; set; }
    public virtual Limit Same { get; set; }
    public virtual Limit Add { get; set; }
    public virtual Limit Sub { get; set; }
    public virtual Limit Mul { get; set; }
    public virtual Limit Div { get; set; }
    public virtual Limit And { get; set; }
    public virtual Limit Orn { get; set; }
    public virtual Limit Not { get; set; }
    public virtual Limit Less { get; set; }
    public virtual Limit More { get; set; }
    public virtual Limit BraceRoundLite { get; set; }
    public virtual Limit BraceRoundRite { get; set; }
    public virtual Limit BraceCurveLite { get; set; }
    public virtual Limit BraceCurveRite { get; set; }

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
        return this.Array.GetAt(index) as Limit;
    }
}