namespace Class.Node;





public class BitSignRightOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BitSignRightOperate();



        return true;
    }
}