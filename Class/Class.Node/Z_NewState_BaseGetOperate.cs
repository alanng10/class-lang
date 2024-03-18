namespace Class.Node;

public class BaseGetOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BaseGetOperate();
        return true;
    }
}