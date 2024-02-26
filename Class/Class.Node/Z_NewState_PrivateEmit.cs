namespace Class.Node;

public class PrivateEmitNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrivateEmit();
        return true;
    }
}