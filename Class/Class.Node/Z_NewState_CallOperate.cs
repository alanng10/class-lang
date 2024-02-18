namespace Class.Node;





public class CallOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new CallOperate();



        return true;
    }
}