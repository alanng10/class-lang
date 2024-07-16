namespace Class.Node;

public class AreExecuteNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new AreExecute();
        return true;
    }
}