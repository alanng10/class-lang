namespace Class.Node;

public class DivOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new DivOperate();
        return true;
    }
}