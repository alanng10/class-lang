namespace Class.Binary;






public class Module : Any
{
    public virtual ModuleRef Ref { get; set; }
    
    
    
    public virtual Array Class { get; set; }



    public virtual Array Import { get; set; }



    public virtual Array Export { get; set; }



    public virtual Array Base { get; set; }
    
    
    
    public virtual Array Member { get; set; }
    
    
    
    public virtual Array State { get; set; }
}