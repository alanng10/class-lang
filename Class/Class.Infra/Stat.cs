namespace Class.Infra;





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




        this.Quote = "\"";



        this.BackSlash = "\\";



        this.Tab = "\t";



        this.NewLine = "\n";



        
        ModuleInt varInt;

        varInt = new ModuleInt();

        varInt.Init();


        ModuleRef varRef;

        varRef = new ModuleRef();

        varRef.Init();
        
        varRef.Int = varInt;


        this.SystemModuleRef = varRef;
        
        

        return true;
    }
    




    public virtual string Quote { get; set; }




    public virtual string BackSlash { get; set; }
    



    public virtual string Tab { get; set; }




    public virtual string NewLine { get; set; }
    
    
    
    
    
    public virtual ModuleRef SystemModuleRef { get; set; }
}