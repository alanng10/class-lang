namespace Class.Node;

public class BitSignRiteOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BitSignRiteOperate();
        return true;
    }
}