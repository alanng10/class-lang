namespace Class.Node;





public class BitNotOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BitNotOperate();



        return true;
    }
}