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
        this.InitArray();
        this.Count = this.Array.Count;
        this.Index = 0;

        this.Class = this.AddItem("class");
        this.ItemGet = this.AddItem("get");
        this.Set = this.AddItem("set");
        this.ItemThis = this.AddItem("this");
        this.Base = this.AddItem("base");
        this.New = this.AddItem("new");
        this.Share = this.AddItem("share");
        this.Cast = this.AddItem("cast");
        this.Null = this.AddItem("null");
        this.True = this.AddItem("true");
        this.False = this.AddItem("false");
        this.Sign = this.AddItem("sign");
        this.Bit = this.AddItem("bit");
        this.Return = this.AddItem("return");
        this.Inf = this.AddItem("inf");
        this.While = this.AddItem("while");
        this.Prudate = this.AddItem("prudate");
        this.Probate = this.AddItem("probate");
        this.Precate = this.AddItem("precate");
        this.Private = this.AddItem("private");
        return true;
    }

    public virtual Keyword Class { get { return __D_Class; } set { __D_Class = value; } }
    protected Keyword __D_Class;
    public virtual Keyword ItemGet { get { return __D_ItemGet; } set { __D_ItemGet = value; } }
    protected Keyword __D_ItemGet;
    public virtual Keyword Set { get { return __D_Set; } set { __D_Set = value; } }
    protected Keyword __D_Set;
    public virtual Keyword ItemThis { get { return __D_ItemThis; } set { __D_ItemThis = value; } }
    protected Keyword __D_ItemThis;
    public virtual Keyword Base { get { return __D_Base; } set { __D_Base = value; } }
    protected Keyword __D_Base;
    public virtual Keyword New { get { return __D_New; } set { __D_New = value; } }
    protected Keyword __D_New;
    public virtual Keyword Share { get { return __D_Share; } set { __D_Share = value; } }
    protected Keyword __D_Share;
    public virtual Keyword Cast { get { return __D_Cast; } set { __D_Cast = value; } }
    protected Keyword __D_Cast;
    public virtual Keyword Null { get { return __D_Null; } set { __D_Null = value; } }
    protected Keyword __D_Null;
    public virtual Keyword True { get { return __D_True; } set { __D_True = value; } }
    protected Keyword __D_True;
    public virtual Keyword False { get { return __D_False; } set { __D_False = value; } }
    protected Keyword __D_False;
    public virtual Keyword Sign { get { return __D_Sign; } set { __D_Sign = value; } }
    protected Keyword __D_Sign;
    public virtual Keyword Bit { get { return __D_Bit; } set { __D_Bit = value; } }
    protected Keyword __D_Bit;
    public virtual Keyword Return { get { return __D_Return; } set { __D_Return = value; } }
    protected Keyword __D_Return;
    public virtual Keyword Inf { get { return __D_Inf; } set { __D_Inf = value; } }
    protected Keyword __D_Inf;
    public virtual Keyword While { get { return __D_While; } set { __D_While = value; } }
    protected Keyword __D_While;
    public virtual Keyword Prudate { get { return __D_Prudate; } set { __D_Prudate = value; } }
    protected Keyword __D_Prudate;
    public virtual Keyword Probate { get { return __D_Probate; } set { __D_Probate = value; } }
    protected Keyword __D_Probate;
    public virtual Keyword Precate { get { return __D_Precate; } set { __D_Precate = value; } }
    protected Keyword __D_Precate;
    public virtual Keyword Private { get { return __D_Private; } set { __D_Private = value; } }
    protected Keyword __D_Private;

    protected virtual Keyword AddItem(string text)
    {
        Keyword item;
        item = new Keyword();
        item.Init();
        item.Index = this.Index;
        item.Text = text;
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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 20; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual Keyword Get(int index)
    {
        return (Keyword)this.Array.Get(index);
    }
}