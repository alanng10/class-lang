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
        this.AccessInvalid = this.AddItem("AccessInvalid");
        this.GetInvalid = this.AddItem("GetInvalid");
        this.SetInvalid = this.AddItem("SetInvalid");
        this.ParamInvalid = this.AddItem("ParamInvalid");
        this.CallInvalid = this.AddItem("CallInvalid");
        this.OperateInvalid = this.AddItem("OperateInvalid");
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




    public virtual ErrorKind Invalid { get; set; }
    public virtual ErrorKind NameInvalid { get; set; }
    public virtual ErrorKind BaseInvalid { get; set; }
    public virtual ErrorKind MemberInvalid { get; set; }
    public virtual ErrorKind ClassInvalid { get; set; }
    public virtual ErrorKind AccessInvalid { get; set; }
    public virtual ErrorKind GetInvalid { get; set; }
    public virtual ErrorKind SetInvalid { get; set; }
    public virtual ErrorKind ParamInvalid { get; set; }
    public virtual ErrorKind CallInvalid { get; set; }
    public virtual ErrorKind OperateInvalid { get; set; }
    public virtual ErrorKind FieldInvalid { get; set; }
    public virtual ErrorKind MaideInvalid { get; set; }
    public virtual ErrorKind VarInvalid { get; set; }
    public virtual ErrorKind OperandInvalid { get; set; }
    public virtual ErrorKind TargetInvalid { get; set; }
    public virtual ErrorKind ValueInvalid { get; set; }
    public virtual ErrorKind ThisInvalid { get; set; }
    public virtual ErrorKind AnyInvalid { get; set; }
    public virtual ErrorKind ArgueInvalid { get; set; }
    public virtual ErrorKind ResultInvalid { get; set; }
    public virtual ErrorKind CondInvalid { get; set; }
    public virtual ErrorKind BodyInvalid { get; set; }
    public virtual ErrorKind ItemInvalid { get; set; }




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
            return 24;
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