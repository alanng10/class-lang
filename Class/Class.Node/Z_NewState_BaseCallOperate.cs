namespace Class.Node;

public class BaseCallOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BaseCallOperate();
        return true;
    }
}