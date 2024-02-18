namespace Class.Node;





public class BitLeftOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BitLeftOperate();



        return true;
    }
}