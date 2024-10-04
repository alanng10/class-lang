namespace Class.Node;

public class OperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new Operate();
        return true;
    }
}