namespace Saber.Module;

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

        this.NameUnavail = this.AddItem("NameUnavail");
        this.ClassUndefine = this.AddItem("ClassUndefine");
        this.BaseUndefine = this.AddItem("BaseUndefine");
        this.MarkUndefine = this.AddItem("MarkUndefine");
        this.ValueUndefine = this.AddItem("ValueUndefine");
        this.ValueUnassign = this.AddItem("ValueUnassign");
        this.OperandUndefine = this.AddItem("OperandUndefine");
        this.OperandUnassign = this.AddItem("OperandUnassign");
        this.ThisUndefine = this.AddItem("ThisUndefine");
        this.FieldUndefine = this.AddItem("FieldUndefine");
        this.MaideUndefine = this.AddItem("MaideUndefine");
        this.ArgueUnassign = this.AddItem("ArgueUnassign");
        this.AnyUndefine = this.AddItem("AnyUndefine");
        this.CondUndefine = this.AddItem("CondUndefine");
        this.CondUnassign = this.AddItem("CondUnassign");
        this.ResultUndefine = this.AddItem("ResultUndefine");
        this.ResultUnassign = this.AddItem("ResultUnassign");
        this.CastUnachieve = this.AddItem("CastUnachieve");
        this.VarUndefine = this.AddItem("VarUndefine");
        this.ExportUndefine = this.AddItem("ExportUndefine");
        this.ClassUnexport = this.AddItem("ClassUnexport");
        this.FieldUnexport = this.AddItem("FieldUnexport");
        this.MaideUnexport = this.AddItem("MaideUnexport");
        this.EntryUndefine = this.AddItem("EntryUndefine");
        this.EntryUnachieve = this.AddItem("EntryUnachieve");
        this.ModuleUnvalid = this.AddItem("ModuleUnvalid");
        this.ModuleUndefine = this.AddItem("ModuleUndefine");
        this.ImportNameUnavail = this.AddItem("ImportNameUnavail");
        this.ImportClassUndefine = this.AddItem("ImportClassUndefine");
        this.ExportUnvalid = this.AddItem("ExportUnvalid");
        this.ExportUnachieve = this.AddItem("ExportUnachieve");
        this.StorageDestUnvalid = this.AddItem("StorageDestUnvalid");
        this.StorageSourceUnvalid = this.AddItem("StorageSourceUnvalid");
        this.StorageDestUnavail = this.AddItem("StorageDestUnavail");
        this.StorageSourceUnachieve = this.AddItem("StorageSourceUnachieve");
        return true;
    }

    public virtual ErrorKind NameUnavail { get; set; }
    public virtual ErrorKind ClassUndefine { get; set; }
    public virtual ErrorKind BaseUndefine { get; set; }
    public virtual ErrorKind MarkUndefine { get; set; }
    public virtual ErrorKind ValueUndefine { get; set; }
    public virtual ErrorKind ValueUnassign { get; set; }
    public virtual ErrorKind OperandUndefine { get; set; }
    public virtual ErrorKind OperandUnassign { get; set; }
    public virtual ErrorKind ThisUndefine { get; set; }
    public virtual ErrorKind FieldUndefine { get; set; }
    public virtual ErrorKind MaideUndefine { get; set; }
    public virtual ErrorKind ArgueUnassign { get; set; }
    public virtual ErrorKind AnyUndefine { get; set; }
    public virtual ErrorKind CondUndefine { get; set; }
    public virtual ErrorKind CondUnassign { get; set; }
    public virtual ErrorKind ResultUndefine { get; set; }
    public virtual ErrorKind ResultUnassign { get; set; }
    public virtual ErrorKind CastUnachieve { get; set; }
    public virtual ErrorKind VarUndefine { get; set; }
    public virtual ErrorKind ExportUndefine { get; set; }
    public virtual ErrorKind ClassUnexport { get; set; }
    public virtual ErrorKind FieldUnexport { get; set; }
    public virtual ErrorKind MaideUnexport { get; set; }
    public virtual ErrorKind EntryUndefine { get; set; }
    public virtual ErrorKind EntryUnachieve { get; set; }
    public virtual ErrorKind ModuleUnvalid { get; set; }
    public virtual ErrorKind ModuleUndefine { get; set; }
    public virtual ErrorKind ImportNameUnavail { get; set; }
    public virtual ErrorKind ImportClassUndefine { get; set; }
    public virtual ErrorKind ExportUnvalid { get; set; }
    public virtual ErrorKind ExportUnachieve { get; set; }
    public virtual ErrorKind StorageDestUnvalid { get; set; }
    public virtual ErrorKind StorageSourceUnvalid { get; set; }
    public virtual ErrorKind StorageDestUnavail { get; set; }
    public virtual ErrorKind StorageSourceUnachieve { get; set; }

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

    protected virtual long ArrayCount { get { return 35; } set { } }

    public virtual long Count { get; set; }
    
    protected virtual long Index { get; set; }

    public virtual ErrorKind Get(long index)
    {
        return this.Array.GetAt(index) as ErrorKind;
    }
}