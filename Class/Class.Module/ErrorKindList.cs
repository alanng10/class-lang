namespace Class.Refer;

public class ErrorKindList : Any
{
    public static ErrorKindList This { get; } = ShareCreate();

    private static ErrorKindList ShareCreate()
    {
        ErrorKindList share;
        share = new ErrorKindList();
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

        this.NameUnavailable = this.AddItem("NameUnavailable");
        this.ClassUndefined = this.AddItem("ClassUndefined");
        this.BaseUndefined = this.AddItem("BaseUndefined");
        this.TargetUndefined = this.AddItem("TargetUndefined");
        this.ValueUndefined = this.AddItem("ValueUndefined");
        this.ValueUnassignable = this.AddItem("ValueUnassignable");
        this.OperandUndefined = this.AddItem("OperandUndefined");
        this.OperandUnassignable = this.AddItem("OperandUnassignable");
        this.ThisUndefined = this.AddItem("ThisUndefined");
        this.FieldUndefined = this.AddItem("FieldUndefined");
        this.MaideUndefined = this.AddItem("MaideUndefined");
        this.ArgueUnassignable = this.AddItem("ArgueUnassignable");
        this.AnyUndefined = this.AddItem("AnyUndefined");
        this.CondUndefined = this.AddItem("CondUndefined");
        this.CondUnassignable = this.AddItem("CondUnassignable");
        this.ResultUndefined = this.AddItem("ResultUndefined");
        this.ResultUnassignable = this.AddItem("ResultUnassignable");
        this.VarUndefined = this.AddItem("VarUndefined");
        return true;
    }

    public virtual ErrorKind NameUnavailable { get; set; }
    public virtual ErrorKind ClassUndefined { get; set; }
    public virtual ErrorKind BaseUndefined { get; set; }
    public virtual ErrorKind TargetUndefined { get; set; }
    public virtual ErrorKind ValueUndefined { get; set; }
    public virtual ErrorKind ValueUnassignable { get; set; }
    public virtual ErrorKind OperandUndefined { get; set; }
    public virtual ErrorKind OperandUnassignable { get; set; }
    public virtual ErrorKind ThisUndefined { get; set; }
    public virtual ErrorKind FieldUndefined { get; set; }
    public virtual ErrorKind MaideUndefined { get; set; }
    public virtual ErrorKind ArgueUnassignable { get; set; }
    public virtual ErrorKind AnyUndefined { get; set; }
    public virtual ErrorKind CondUndefined { get; set; }
    public virtual ErrorKind CondUnassignable { get; set; }
    public virtual ErrorKind ResultUndefined { get; set; }
    public virtual ErrorKind ResultUnassignable { get; set; }
    public virtual ErrorKind VarUndefined { get; set; }

    protected virtual ErrorKind AddItem(string text)
    {
        ErrorKind item;
        item = new ErrorKind();
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

    protected virtual Array Array { get; set; }

    protected virtual int ArrayCount
    { 
        get
        {
            return 18;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual ErrorKind Get(int index)
    {
        return (ErrorKind)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}