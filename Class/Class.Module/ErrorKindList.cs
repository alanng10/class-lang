namespace Class.Module;

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
        this.CastUnachievable = this.AddItem("CastUnachievable");
        this.EqualUnachievable = this.AddItem("EqualUnachievable");
        this.CondUndefined = this.AddItem("CondUndefined");
        this.CondUnassignable = this.AddItem("CondUnassignable");
        this.ResultUndefined = this.AddItem("ResultUndefined");
        this.ResultUnassignable = this.AddItem("ResultUnassignable");
        this.VarUndefined = this.AddItem("VarUndefined");
        this.ExportUndefined = this.AddItem("ExportUndefined");
        this.ClassUnexportable = this.AddItem("ClassUnexportable");
        this.FieldUnexportable = this.AddItem("FieldUnexportable");
        this.MaideUnexportable = this.AddItem("MaideUnexportable");
        this.EntryUndefined = this.AddItem("EntryUndefined");
        this.EntryUnachievable = this.AddItem("EntryUnachievable");
        return true;
    }

    public virtual ErrorKind NameUnavailable { get { return __D_NameUnavailable; } set { __D_NameUnavailable = value; } }
    protected ErrorKind __D_NameUnavailable;
    public virtual ErrorKind ClassUndefined { get { return __D_ClassUndefined; } set { __D_ClassUndefined = value; } }
    protected ErrorKind __D_ClassUndefined;
    public virtual ErrorKind BaseUndefined { get { return __D_BaseUndefined; } set { __D_BaseUndefined = value; } }
    protected ErrorKind __D_BaseUndefined;
    public virtual ErrorKind TargetUndefined { get { return __D_TargetUndefined; } set { __D_TargetUndefined = value; } }
    protected ErrorKind __D_TargetUndefined;
    public virtual ErrorKind ValueUndefined { get { return __D_ValueUndefined; } set { __D_ValueUndefined = value; } }
    protected ErrorKind __D_ValueUndefined;
    public virtual ErrorKind ValueUnassignable { get { return __D_ValueUnassignable; } set { __D_ValueUnassignable = value; } }
    protected ErrorKind __D_ValueUnassignable;
    public virtual ErrorKind OperandUndefined { get { return __D_OperandUndefined; } set { __D_OperandUndefined = value; } }
    protected ErrorKind __D_OperandUndefined;
    public virtual ErrorKind OperandUnassignable { get { return __D_OperandUnassignable; } set { __D_OperandUnassignable = value; } }
    protected ErrorKind __D_OperandUnassignable;
    public virtual ErrorKind ThisUndefined { get { return __D_ThisUndefined; } set { __D_ThisUndefined = value; } }
    protected ErrorKind __D_ThisUndefined;
    public virtual ErrorKind FieldUndefined { get { return __D_FieldUndefined; } set { __D_FieldUndefined = value; } }
    protected ErrorKind __D_FieldUndefined;
    public virtual ErrorKind MaideUndefined { get { return __D_MaideUndefined; } set { __D_MaideUndefined = value; } }
    protected ErrorKind __D_MaideUndefined;
    public virtual ErrorKind ArgueUnassignable { get { return __D_ArgueUnassignable; } set { __D_ArgueUnassignable = value; } }
    protected ErrorKind __D_ArgueUnassignable;
    public virtual ErrorKind AnyUndefined { get { return __D_AnyUndefined; } set { __D_AnyUndefined = value; } }
    protected ErrorKind __D_AnyUndefined;
    public virtual ErrorKind CastUnachievable { get { return __D_CastUnachievable; } set { __D_CastUnachievable = value; } }
    protected ErrorKind __D_CastUnachievable;
    public virtual ErrorKind EqualUnachievable { get { return __D_EqualUnachievable; } set { __D_EqualUnachievable = value; } }
    protected ErrorKind __D_EqualUnachievable;
    public virtual ErrorKind CondUndefined { get { return __D_CondUndefined; } set { __D_CondUndefined = value; } }
    protected ErrorKind __D_CondUndefined;
    public virtual ErrorKind CondUnassignable { get { return __D_CondUnassignable; } set { __D_CondUnassignable = value; } }
    protected ErrorKind __D_CondUnassignable;
    public virtual ErrorKind ResultUndefined { get { return __D_ResultUndefined; } set { __D_ResultUndefined = value; } }
    protected ErrorKind __D_ResultUndefined;
    public virtual ErrorKind ResultUnassignable { get { return __D_ResultUnassignable; } set { __D_ResultUnassignable = value; } }
    protected ErrorKind __D_ResultUnassignable;
    public virtual ErrorKind VarUndefined { get { return __D_VarUndefined; } set { __D_VarUndefined = value; } }
    protected ErrorKind __D_VarUndefined;
    public virtual ErrorKind ExportUndefined { get { return __D_ExportUndefined; } set { __D_ExportUndefined = value; } }
    protected ErrorKind __D_ExportUndefined;
    public virtual ErrorKind ClassUnexportable { get { return __D_ClassUnexportable; } set { __D_ClassUnexportable = value; } }
    protected ErrorKind __D_ClassUnexportable;
    public virtual ErrorKind FieldUnexportable { get { return __D_FieldUnexportable; } set { __D_FieldUnexportable = value; } }
    protected ErrorKind __D_FieldUnexportable;
    public virtual ErrorKind MaideUnexportable { get { return __D_MaideUnexportable; } set { __D_MaideUnexportable = value; } }
    protected ErrorKind __D_MaideUnexportable;
    public virtual ErrorKind EntryUndefined { get { return __D_EntryUndefined; } set { __D_EntryUndefined = value; } }
    protected ErrorKind __D_EntryUndefined;
    public virtual ErrorKind EntryUnachievable { get { return __D_EntryUnachievable; } set { __D_EntryUnachievable = value; } }
    protected ErrorKind __D_EntryUnachievable;

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

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 26; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual ErrorKind Get(int index)
    {
        return (ErrorKind)this.Array.Get(index);
    }
}