namespace Class.Node;

public class ShareOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ShareOperate();
        return true;
    }
}