namespace Saber.Node;

public class CreateSetStateArg : Any
{
    public virtual Node Node { get; set; }
    public virtual CreateSetArg SetArg { get; set; }
}