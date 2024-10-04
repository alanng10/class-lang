namespace Class.Info;

public class Node : Any
{
    public virtual String Name { get; set; }

    public virtual String NameString { get; set; }

    public virtual Table Child { get; set; }
}