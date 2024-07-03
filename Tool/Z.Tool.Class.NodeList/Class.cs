namespace Z.Tool.Class.NodeList;

public class Class : Any
{
    public virtual string Name { get; set; }
    public virtual string Base { get; set; }
    public virtual Array Field { get; set; }
    
    public virtual Table Derive { get; set; }
}