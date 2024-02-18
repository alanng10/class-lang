namespace Class.Node;





public class ProbateAccessNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ProbateAccess();



        return true;
    }
}