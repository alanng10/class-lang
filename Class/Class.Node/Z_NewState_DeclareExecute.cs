namespace Class.Node;

public class DeclareExecuteNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new DeclareExecute();
        return true;
    }
}