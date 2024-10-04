namespace Class.Node;

public class BitLiteOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BitLiteOperate();
        return true;
    }
}