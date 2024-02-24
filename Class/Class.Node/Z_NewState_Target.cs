namespace Class.Node;

public class TargetNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Target();
        return true;
    }
}