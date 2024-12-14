namespace Saber.Docue;

public class Node : Any
{
    public virtual String Name { get; set; }

    public virtual Table Child { get; set; }
}