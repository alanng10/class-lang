namespace Class.Node;

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

        this.Invalid = this.AddItem("Invalid");
        this.NameInvalid = this.AddItem("NameInvalid");
        this.BaseInvalid = this.AddItem("BaseInvalid");
        this.MemberInvalid = this.AddItem("MemberInvalid");
        this.ClassInvalid = this.AddItem("ClassInvalid");
        this.CountInvalid = this.AddItem("CountInvalid");
        this.GetInvalid = this.AddItem("GetInvalid");
        this.SetInvalid = this.AddItem("SetInvalid");
        this.ParamInvalid = this.AddItem("ParamInvalid");
        this.CallInvalid = this.AddItem("CallInvalid");
        this.FieldInvalid = this.AddItem("FieldInvalid");
        this.MaideInvalid = this.AddItem("MaideInvalid");
        this.VarInvalid = this.AddItem("VarInvalid");
        this.OperandInvalid = this.AddItem("OperandInvalid");
        this.TargetInvalid = this.AddItem("TargetInvalid");
        this.ValueInvalid = this.AddItem("ValueInvalid");
        this.ThisInvalid = this.AddItem("ThisInvalid");
        this.AnyInvalid = this.AddItem("AnyInvalid");
        this.ArgueInvalid = this.AddItem("ArgueInvalid");
        this.ResultInvalid = this.AddItem("ResultInvalid");
        this.CondInvalid = this.AddItem("CondInvalid");
        this.BodyInvalid = this.AddItem("BodyInvalid");
        this.ItemInvalid = this.AddItem("ItemInvalid");
        return true;
    }

    public virtual ErrorKind Invalid { get { return __D_Invalid; } set { __D_Invalid = value; } }
    protected ErrorKind __D_Invalid;
    public virtual ErrorKind NameInvalid { get { return __D_NameInvalid; } set { __D_NameInvalid = value; } }
    protected ErrorKind __D_NameInvalid;
    public virtual ErrorKind BaseInvalid { get { return __D_BaseInvalid; } set { __D_BaseInvalid = value; } }
    protected ErrorKind __D_BaseInvalid;
    public virtual ErrorKind MemberInvalid { get { return __D_MemberInvalid; } set { __D_MemberInvalid = value; } }
    protected ErrorKind __D_MemberInvalid;
    public virtual ErrorKind ClassInvalid { get { return __D_ClassInvalid; } set { __D_ClassInvalid = value; } }
    protected ErrorKind __D_ClassInvalid;
    public virtual ErrorKind CountInvalid { get { return __D_CountInvalid; } set { __D_CountInvalid = value; } }
    protected ErrorKind __D_CountInvalid;
    public virtual ErrorKind GetInvalid { get { return __D_GetInvalid; } set { __D_GetInvalid = value; } }
    protected ErrorKind __D_GetInvalid;
    public virtual ErrorKind SetInvalid { get { return __D_SetInvalid; } set { __D_SetInvalid = value; } }
    protected ErrorKind __D_SetInvalid;
    public virtual ErrorKind ParamInvalid { get { return __D_ParamInvalid; } set { __D_ParamInvalid = value; } }
    protected ErrorKind __D_ParamInvalid;
    public virtual ErrorKind CallInvalid { get { return __D_CallInvalid; } set { __D_CallInvalid = value; } }
    protected ErrorKind __D_CallInvalid;
    public virtual ErrorKind FieldInvalid { get { return __D_FieldInvalid; } set { __D_FieldInvalid = value; } }
    protected ErrorKind __D_FieldInvalid;
    public virtual ErrorKind MaideInvalid { get { return __D_MaideInvalid; } set { __D_MaideInvalid = value; } }
    protected ErrorKind __D_MaideInvalid;
    public virtual ErrorKind VarInvalid { get { return __D_VarInvalid; } set { __D_VarInvalid = value; } }
    protected ErrorKind __D_VarInvalid;
    public virtual ErrorKind OperandInvalid { get { return __D_OperandInvalid; } set { __D_OperandInvalid = value; } }
    protected ErrorKind __D_OperandInvalid;
    public virtual ErrorKind TargetInvalid { get { return __D_TargetInvalid; } set { __D_TargetInvalid = value; } }
    protected ErrorKind __D_TargetInvalid;
    public virtual ErrorKind ValueInvalid { get { return __D_ValueInvalid; } set { __D_ValueInvalid = value; } }
    protected ErrorKind __D_ValueInvalid;
    public virtual ErrorKind ThisInvalid { get { return __D_ThisInvalid; } set { __D_ThisInvalid = value; } }
    protected ErrorKind __D_ThisInvalid;
    public virtual ErrorKind AnyInvalid { get { return __D_AnyInvalid; } set { __D_AnyInvalid = value; } }
    protected ErrorKind __D_AnyInvalid;
    public virtual ErrorKind ArgueInvalid { get { return __D_ArgueInvalid; } set { __D_ArgueInvalid = value; } }
    protected ErrorKind __D_ArgueInvalid;
    public virtual ErrorKind ResultInvalid { get { return __D_ResultInvalid; } set { __D_ResultInvalid = value; } }
    protected ErrorKind __D_ResultInvalid;
    public virtual ErrorKind CondInvalid { get { return __D_CondInvalid; } set { __D_CondInvalid = value; } }
    protected ErrorKind __D_CondInvalid;
    public virtual ErrorKind BodyInvalid { get { return __D_BodyInvalid; } set { __D_BodyInvalid = value; } }
    protected ErrorKind __D_BodyInvalid;
    public virtual ErrorKind ItemInvalid { get { return __D_ItemInvalid; } set { __D_ItemInvalid = value; } }
    protected ErrorKind __D_ItemInvalid;

    protected virtual ErrorKind AddItem(string text)
    {
        ErrorKind item;
        item = new ErrorKind();
        item.Init();
        item.Index = this.Index;
        item.Text = text;
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

    protected virtual int ArrayCount { get { return 23; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual ErrorKind Get(int index)
    {
        return (ErrorKind)this.Array.GetAt(index);
    }
}