namespace Saber.Node;

public class SubOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new SubOperate();
        return true;
    }
}