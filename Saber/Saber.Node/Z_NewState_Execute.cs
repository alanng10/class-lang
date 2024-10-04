namespace Saber.Node;

public class ExecuteNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Execute();
        return true;
    }
}