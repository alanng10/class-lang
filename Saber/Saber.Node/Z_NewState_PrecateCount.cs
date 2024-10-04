namespace Saber.Node;

public class PrecateCountNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrecateCount();
        return true;
    }
}