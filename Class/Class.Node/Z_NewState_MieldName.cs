namespace Class.Node;





public class MieldNameNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new MieldName();



        return true;
    }
}