namespace Class.Node;

public class ArgueNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Argue();
        return true;
    }
}