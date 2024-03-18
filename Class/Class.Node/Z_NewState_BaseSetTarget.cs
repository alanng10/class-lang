namespace Class.Node;

public class BaseSetTargetNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BaseSetTarget();
        return true;
    }
}