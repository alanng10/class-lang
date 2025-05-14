namespace Saber.Node;

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
        this.StringValue = TextStringValue.This;
        this.InitArray();
        this.Count = this.Array.Count;
        this.Index = 0;

        this.Unvalid = this.AddItem("Unvalid");
        this.NameUnvalid = this.AddItem("NameUnvalid");
        this.BaseUnvalid = this.AddItem("BaseUnvalid");
        this.PartUnvalid = this.AddItem("PartUnvalid");
        this.ClassUnvalid = this.AddItem("ClassUnvalid");
        this.CountUnvalid = this.AddItem("CountUnvalid");
        this.GetUnvalid = this.AddItem("GetUnvalid");
        this.SetUnvalid = this.AddItem("SetUnvalid");
        this.ParamUnvalid = this.AddItem("ParamUnvalid");
        this.CallUnvalid = this.AddItem("CallUnvalid");
        this.FieldUnvalid = this.AddItem("FieldUnvalid");
        this.MaideUnvalid = this.AddItem("MaideUnvalid");
        this.VarUnvalid = this.AddItem("VarUnvalid");
        this.OperandUnvalid = this.AddItem("OperandUnvalid");
        this.MarkUnvalid = this.AddItem("MarkUnvalid");
        this.ValueUnvalid = this.AddItem("ValueUnvalid");
        this.ThisUnvalid = this.AddItem("ThisUnvalid");
        this.AnyUnvalid = this.AddItem("AnyUnvalid");
        this.ArgueUnvalid = this.AddItem("ArgueUnvalid");
        this.ResultUnvalid = this.AddItem("ResultUnvalid");
        this.CondUnvalid = this.AddItem("CondUnvalid");
        this.BodyUnvalid = this.AddItem("BodyUnvalid");
        this.ItemUnvalid = this.AddItem("ItemUnvalid");
        return true;
    }

    public virtual ErrorKind Unvalid { get; set; }
    public virtual ErrorKind NameUnvalid { get; set; }
    public virtual ErrorKind BaseUnvalid { get; set; }
    public virtual ErrorKind PartUnvalid { get; set; }
    public virtual ErrorKind ClassUnvalid { get; set; }
    public virtual ErrorKind CountUnvalid { get; set; }
    public virtual ErrorKind GetUnvalid { get; set; }
    public virtual ErrorKind SetUnvalid { get; set; }
    public virtual ErrorKind ParamUnvalid { get; set; }
    public virtual ErrorKind CallUnvalid { get; set; }
    public virtual ErrorKind FieldUnvalid { get; set; }
    public virtual ErrorKind MaideUnvalid { get; set; }
    public virtual ErrorKind VarUnvalid { get; set; }
    public virtual ErrorKind OperandUnvalid { get; set; }
    public virtual ErrorKind MarkUnvalid { get; set; }
    public virtual ErrorKind ValueUnvalid { get; set; }
    public virtual ErrorKind ThisUnvalid { get; set; }
    public virtual ErrorKind AnyUnvalid { get; set; }
    public virtual ErrorKind ArgueUnvalid { get; set; }
    public virtual ErrorKind ResultUnvalid { get; set; }
    public virtual ErrorKind CondUnvalid { get; set; }
    public virtual ErrorKind BodyUnvalid { get; set; }
    public virtual ErrorKind ItemUnvalid { get; set; }

    protected virtual TextStringValue StringValue { get; set; }

    protected virtual ErrorKind AddItem(string text)
    {
        String k;
        k = this.StringValue.Execute(text);

        ErrorKind item;
        item = new ErrorKind();
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

    public virtual ErrorKind Get(long index)
    {
        return this.Array.GetAt(index) as ErrorKind;
    }
}