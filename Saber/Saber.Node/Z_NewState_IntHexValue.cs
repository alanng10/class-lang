namespace Saber.Node;

public class IntHexValueNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new IntHexValue();
        return true;
    }
}