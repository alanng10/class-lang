namespace Saber.Node;

public class MulOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new MulOperate();
        return true;
    }
}