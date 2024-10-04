namespace Class.Node;

public class StringValueNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new StringValue();
        return true;
    }
}