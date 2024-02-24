namespace Class.Node;

public class ValueNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Value();
        return true;
    }
}