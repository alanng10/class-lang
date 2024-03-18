namespace Class.Check;





public class SystemClass : Any
{
    public InfraClass Any { get; set; }




    public InfraClass Bool { get; set; }




    public InfraClass Int { get; set; }




    public InfraClass String { get; set; }






    public override bool Init()
    {
        base.Init();


        
        this.Any = this.NewClass("Any");




        this.Bool = this.NewClass("Bool");




        this.Int = this.NewClass("Int");




        this.String = this.NewClass("String");




        return true;
    }

    private InfraClass NewClass(string name)
    {
        InfraClass c;


        c = new InfraClass();


        c.Init();


        c.Name = name;





        InfraClass ret;


        ret = c;



        return ret;
    }
}