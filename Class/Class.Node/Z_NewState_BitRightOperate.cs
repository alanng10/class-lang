namespace Class.Node;

public class BitRightOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BitRightOperate();
        return true;
    }
}