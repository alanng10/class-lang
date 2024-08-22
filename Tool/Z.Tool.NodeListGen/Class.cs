namespace Z.Tool.NodeListGen;

public class Class : Any
{
    public virtual String Name { get; set; }
    public virtual String Base { get; set; }
    public virtual Table Field { get; set; }
    
    public virtual Table Derive { get; set; }

    public virtual long AnyInt { get; set; }
}