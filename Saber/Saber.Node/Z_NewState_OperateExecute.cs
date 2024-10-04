namespace Saber.Node;

public class OperateExecuteNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new OperateExecute();
        return true;
    }
}