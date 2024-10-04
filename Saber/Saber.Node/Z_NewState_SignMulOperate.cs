namespace Saber.Node;

public class SignMulOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new SignMulOperate();
        return true;
    }
}