namespace Class.Infra;





public class DelimitList : Any
{
    public static DelimitList This { get; } = CreateShare();




    private static DelimitList CreateShare()
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
        this.ExpoSign = this.AddItem("^");
        this.LeftBracket = this.AddItem("(");
        this.RightBracket = this.AddItem(")");
        this.LeftBrace = this.AddItem("{");
        this.RightBrace = this.AddItem("}");






        return true;
    }




    public virtual Delimit StopSign { get; set; }
    public virtual Delimit PauseSign { get; set; }
    public virtual Delimit BaseSign { get; set; }
    public virtual Delimit ExecuteSign { get; set; }
    public virtual Delimit EqualSign { get; set; }
    public virtual Delimit AddSign { get; set; }
    public virtual Delimit SubSign { get; set; }
    public virtual Delimit MulSign { get; set; }
    public virtual Delimit DivSign { get; set; }
    public virtual Delimit AndSign { get; set; }
    public virtual Delimit OrnSign { get; set; }
    public virtual Delimit NotSign { get; set; }
    public virtual Delimit LessSign { get; set; }
    public virtual Delimit MoreSign { get; set; }
    public virtual Delimit ExpoSign { get; set; }
    public virtual Delimit LeftBracket { get; set; }
    public virtual Delimit RightBracket { get; set; }
    public virtual Delimit LeftBrace { get; set; }
    public virtual Delimit RightBrace { get; set; }




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





    protected virtual Array Array { get; set; }



    protected virtual int ArrayCount
    { 
        get
        {
            return 19;
        } 
        set
        {
        }
    }




    public virtual int Count { get; set; }




    public virtual Delimit Get(int index)
    {
        return (Delimit)this.Array.Get(index);
    }



    
    protected virtual int Index { get; set; }

}