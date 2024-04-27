namespace Class.Refer;





public class SystemClass : Any
{
    public virtual ClassClass Any { get; set; }




    public virtual ClassClass Bool { get; set; }




    public virtual ClassClass Int { get; set; }




    public virtual ClassClass String { get; set; }






    public override bool Init()
    {
        base.Init();


        
        this.Any = this.NewClass("Any");




        this.Bool = this.NewClass("Bool");




        this.Int = this.NewClass("Int");




        this.String = this.NewClass("String");




        return true;
    }

    private ClassClass NewClass(string name)
    {
        ClassClass c;


        c = new ClassClass();


        c.Init();


        c.Name = name;





        ClassClass ret;


        ret = c;



        return ret;
    }
}