namespace Z.Tool.Class.NodeList;

public class Class : Any
{
    public virtual String Name { get; set; }
    public virtual String Base { get; set; }
    public virtual Table Field { get; set; }
    
    public virtual Table Derive { get; set; }

    public virtual int AnyInt { get; set; }
}