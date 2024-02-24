namespace Class.Node;

public class BoolValueNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BoolValue();
        return true;
    }
}