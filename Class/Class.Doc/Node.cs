namespace Class.Doc;

public class Node : Any
{
    public virtual string Name { get; set; }

    public virtual string NameString { get; set; }

    public virtual Table Child { get; set; }
}