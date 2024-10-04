namespace Saber.Node;

public class BraceOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BraceOperate();
        return true;
    }
}