namespace Class.Node;





public class PrecateAccessNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrecateAccess();



        return true;
    }
}