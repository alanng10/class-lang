namespace Class.Node;





public class InfExecuteNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new InfExecute();



        return true;
    }
}