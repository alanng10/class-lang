namespace Class.Node;

public class PrivateCountNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrivateCount();
        return true;
    }
}