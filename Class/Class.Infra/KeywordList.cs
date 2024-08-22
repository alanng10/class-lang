namespace Class.Infra;

public class KeywordList : Any
{
    public static KeywordList This { get; } = ShareCreate();

    private static KeywordList ShareCreate()
    {
        KeywordList share;
        share = new KeywordList();
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

        this.Class = this.AddItem("class");
        this.Field = this.AddItem("field");
        this.Maide = this.AddItem("maide");
        this.Var = this.AddItem("var");
        this.ItemGet = this.AddItem("get");
        this.Set = this.AddItem("set");
        this.ItemThis = this.AddItem("this");
        this.Base = this.AddItem("base");
        this.Return = this.AddItem("return");
        this.Inf = this.AddItem("inf");
        this.While = this.AddItem("while");
        this.New = this.AddItem("new");
        this.Share = this.AddItem("share");
        this.Cast = this.AddItem("cast");
        this.Null = this.AddItem("null");
        this.True = this.AddItem("true");
        this.False = this.AddItem("false");
        this.Sign = this.AddItem("sign");
        this.Bit = this.AddItem("bit");
        this.Prusate = this.AddItem("prusate");
        this.Precate = this.AddItem("precate");
        this.Pronate = this.AddItem("pronate");
        this.Private = this.AddItem("private");
        return true;
    }

    public virtual Keyword Class { get; set; }
    public virtual Keyword Field { get; set; }
    public virtual Keyword Maide { get; set; }
    public virtual Keyword Var { get; set; }
    public virtual Keyword ItemGet { get; set; }
    public virtual Keyword Set { get; set; }
    public virtual Keyword ItemThis { get; set; }
    public virtual Keyword Base { get; set; }
    public virtual Keyword Return { get; set; }
    public virtual Keyword Inf { get; set; }
    public virtual Keyword While { get; set; }
    public virtual Keyword New { get; set; }
    public virtual Keyword Share { get; set; }
    public virtual Keyword Cast { get; set; }
    public virtual Keyword Null { get; set; }
    public virtual Keyword True { get; set; }
    public virtual Keyword False { get; set; }
    public virtual Keyword Sign { get; set; }
    public virtual Keyword Bit { get; set; }
    public virtual Keyword Prusate { get; set; }
    public virtual Keyword Precate { get; set; }
    public virtual Keyword Pronate { get; set; }
    public virtual Keyword Private { get; set; }

    protected virtual StringValue StringValue { get; set; }

    protected virtual Keyword AddItem(string text)
    {
        String k;
        k = this.StringValue.Execute(text);

        Keyword item;
        item = new Keyword();
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

    protected virtual long ArrayCount { get { return 23; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual Keyword Get(long index)
    {
        return (Keyword)this.Array.GetAt(index);
    }
}