namespace Class.Infra;

public class DelimitList : Any
{
    public static DelimitList This { get; } = ShareCreate();

    private static DelimitList ShareCreate()
    {
        DelimitList share;
        share = new DelimitList();
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

        this.StopSign = this.AddItem(".");
        this.PauseSign = this.AddItem(",");
        this.BaseSign = this.AddItem(":");
        this.ExecuteSign = this.AddItem(";");
        this.EqualSign = this.AddItem("=");
        this.AddSign = this.AddItem("+");
        this.SubSign = this.AddItem("-");
        this.MulSign = this.AddItem("*");
        this.DivSign = this.AddItem("/");
        this.AndSign = this.AddItem("&");
        this.OrnSign = this.AddItem("|");
        this.NotSign = this.AddItem("!");
        this.LessSign = this.AddItem("<");
        this.MoreSign = this.AddItem(">");
        this.LeftBracket = this.AddItem("(");
        this.RightBracket = this.AddItem(")");
        this.LeftBrace = this.AddItem("{");
        this.RightBrace = this.AddItem("}");
        return true;
    }

    public virtual Delimit StopSign { get { return __D_StopSign; } set { __D_StopSign = value; } }
    protected Delimit __D_StopSign;
    public virtual Delimit PauseSign { get { return __D_PauseSign; } set { __D_PauseSign = value; } }
    protected Delimit __D_PauseSign;
    public virtual Delimit BaseSign { get { return __D_BaseSign; } set { __D_BaseSign = value; } }
    protected Delimit __D_BaseSign;
    public virtual Delimit ExecuteSign { get { return __D_ExecuteSign; } set { __D_ExecuteSign = value; } }
    protected Delimit __D_ExecuteSign;
    public virtual Delimit EqualSign { get { return __D_EqualSign; } set { __D_EqualSign = value; } }
    protected Delimit __D_EqualSign;
    public virtual Delimit AddSign { get { return __D_AddSign; } set { __D_AddSign = value; } }
    protected Delimit __D_AddSign;
    public virtual Delimit SubSign { get { return __D_SubSign; } set { __D_SubSign = value; } }
    protected Delimit __D_SubSign;
    public virtual Delimit MulSign { get { return __D_MulSign; } set { __D_MulSign = value; } }
    protected Delimit __D_MulSign;
    public virtual Delimit DivSign { get { return __D_DivSign; } set { __D_DivSign = value; } }
    protected Delimit __D_DivSign;
    public virtual Delimit AndSign { get { return __D_AndSign; } set { __D_AndSign = value; } }
    protected Delimit __D_AndSign;
    public virtual Delimit OrnSign { get { return __D_OrnSign; } set { __D_OrnSign = value; } }
    protected Delimit __D_OrnSign;
    public virtual Delimit NotSign { get { return __D_NotSign; } set { __D_NotSign = value; } }
    protected Delimit __D_NotSign;
    public virtual Delimit LessSign { get { return __D_LessSign; } set { __D_LessSign = value; } }
    protected Delimit __D_LessSign;
    public virtual Delimit MoreSign { get { return __D_MoreSign; } set { __D_MoreSign = value; } }
    protected Delimit __D_MoreSign;
    public virtual Delimit LeftBracket { get { return __D_LeftBracket; } set { __D_LeftBracket = value; } }
    protected Delimit __D_LeftBracket;
    public virtual Delimit RightBracket { get { return __D_RightBracket; } set { __D_RightBracket = value; } }
    protected Delimit __D_RightBracket;
    public virtual Delimit LeftBrace { get { return __D_LeftBrace; } set { __D_LeftBrace = value; } }
    protected Delimit __D_LeftBrace;
    public virtual Delimit RightBrace { get { return __D_RightBrace; } set { __D_RightBrace = value; } }
    protected Delimit __D_RightBrace;

    protected virtual Delimit AddItem(string text)
    {
        Delimit item;
        item = new Delimit();
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

    protected virtual int ArrayCount { get { return 18; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual Delimit Get(int index)
    {
        return (Delimit)this.Array.Get(index);
    }
}