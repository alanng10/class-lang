namespace Class.Node;

public class PartNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Part();
        return true;
    }
}