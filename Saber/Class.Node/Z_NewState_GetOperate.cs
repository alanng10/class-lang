namespace Class.Node;

public class GetOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new GetOperate();
        return true;
    }
}