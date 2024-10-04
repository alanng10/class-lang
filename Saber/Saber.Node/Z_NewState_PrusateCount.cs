namespace Saber.Node;

public class PrusateCountNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrusateCount();
        return true;
    }
}