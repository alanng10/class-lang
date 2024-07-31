namespace Class.Node;

public class BaseOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BaseOperate();
        return true;
    }
}