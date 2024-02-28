namespace Class.Node;

public class PrudateCountNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrudateCount();
        return true;
    }
}