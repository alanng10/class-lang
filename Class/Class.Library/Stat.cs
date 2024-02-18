namespace Class.Library;





public class Stat : Any
{
    public static Stat This { get; } = CreateShare();




    private static Stat CreateShare()
    {
        Stat share;


        share = new Stat();



        Any a;


        a = share;


        a.Init();



        return share;
    }






    public override bool Init()
    {
        base.Init();


        
        this.IntTypeName = "Int";
        
        
        this.BoolTypeName = "Bool";
        
        
        this.SIntTypeName = "SInt";
        
        
        this.ByteTypeName = "Byte";
        
        
        this.CharTypeName = "Char";


        
        this.ReturnWord = "return";
        
        
        this.GotoWord = "goto";


        
        

        return true;
    }
    



    public virtual string IntTypeName { get; set; }
    
    
    public virtual string BoolTypeName { get; set; }
    
    
    public virtual string SIntTypeName { get; set; }
    
    
    public virtual string ByteTypeName { get; set; }
    
    
    public virtual string CharTypeName { get; set; }
    
    
    
    public virtual string ReturnWord { get; set; }
    
    
    public virtual string GotoWord { get; set; }
}