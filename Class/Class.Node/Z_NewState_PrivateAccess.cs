namespace Class.Node;

public class PrivateAccessNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrivateAccess();
        return true;
    }
}