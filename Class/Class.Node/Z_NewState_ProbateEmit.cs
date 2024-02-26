namespace Class.Node;

public class ProbateEmitNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ProbateEmit();
        return true;
    }
}