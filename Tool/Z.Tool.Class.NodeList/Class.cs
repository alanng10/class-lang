namespace Z.Tool.Class.NodeList;

public class Class : Any
{
    public virtual Table Derive { get; set; }

    public virtual string Name { get; set; }
    public virtual string Base { get; set; }
    public virtual Array Field { get; set; }
}