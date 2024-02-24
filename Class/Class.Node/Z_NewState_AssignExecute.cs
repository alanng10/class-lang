namespace Class.Node;

public class AssignExecuteNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new AssignExecute();
        return true;
    }
}