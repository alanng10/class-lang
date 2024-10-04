namespace Saber.Node;

public class Class : Node
{
    public virtual ClassName Name { get; set; }
    public virtual ClassName Base { get; set; }
    public virtual Part Part { get; set; }
}