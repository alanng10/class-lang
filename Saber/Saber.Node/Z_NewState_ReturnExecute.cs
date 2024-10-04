namespace Saber.Node;

public class ReturnExecuteNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ReturnExecute();
        return true;
    }
}