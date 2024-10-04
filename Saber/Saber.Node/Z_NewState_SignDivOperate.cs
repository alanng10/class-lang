namespace Saber.Node;

public class SignDivOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new SignDivOperate();
        return true;
    }
}