namespace Saber.Node;

public class WhileExecuteNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new WhileExecute();
        return true;
    }
}