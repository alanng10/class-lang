namespace Class.Infra;

public class IndexList : Any
{
    public static IndexList This { get; } = ShareCreate();

    private static IndexList ShareCreate()
    {
        IndexList share;
        share = new IndexList();
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

    public virtual Index Class { get; set; }
    public virtual Index Field { get; set; }
    public virtual Index Maide { get; set; }
    public virtual Index Var { get; set; }
    public virtual Index ItemGet { get; set; }
    public virtual Index Set { get; set; }
    public virtual Index ItemThis { get; set; }
    public virtual Index Base { get; set; }
    public virtual Index Return { get; set; }
    public virtual Index Inf { get; set; }
    public virtual Index While { get; set; }
    public virtual Index New { get; set; }
    public virtual Index Share { get; set; }
    public virtual Index Cast { get; set; }
    public virtual Index Null { get; set; }
    public virtual Index True { get; set; }
    public virtual Index False { get; set; }
    public virtual Index Sign { get; set; }
    public virtual Index Bit { get; set; }
    public virtual Index Prusate { get; set; }
    public virtual Index Precate { get; set; }
    public virtual Index Pronate { get; set; }
    public virtual Index Private { get; set; }

    protected virtual StringValue StringValue { get; set; }

    protected virtual Index AddItem(string text)
    {
        String k;
        k = this.StringValue.Execute(text);

        Index item;
        item = new Index();
        item.Init();
        item.IndexList = this.Index;
        item.Text = k;
        this.Array.SetAt(item.IndexList, item);
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

    public virtual Index Get(long index)
    {
        return (Index)this.Array.GetAt(index);
    }
}