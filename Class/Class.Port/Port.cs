namespace Class.Port;




public class Port : Any
{
    public virtual ModuleRef Ref { get; set; }



    public virtual Array Import { get; set; }



    public virtual Array Export { get; set; }



    public virtual Array File { get; set; }
}