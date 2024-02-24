namespace Class.Node;

public class IntSignValueNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new IntSignValue();
        return true;
    }
}