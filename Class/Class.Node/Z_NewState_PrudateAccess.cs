namespace Class.Node;





public class PrudateAccessNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new PrudateAccess();



        return true;
    }
}