namespace Saber.Node;

public class ReferExecuteNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ReferExecute();
        return true;
    }
}