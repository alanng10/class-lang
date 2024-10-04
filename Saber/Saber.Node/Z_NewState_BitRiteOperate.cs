namespace Saber.Node;

public class BitRiteOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BitRiteOperate();
        return true;
    }
}