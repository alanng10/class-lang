namespace Class.Node;

public class ProbateCountNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ProbateCount();
        return true;
    }
}