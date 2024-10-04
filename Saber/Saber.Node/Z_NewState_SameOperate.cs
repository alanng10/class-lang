namespace Saber.Node;

public class SameOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new SameOperate();
        return true;
    }
}