namespace Class.Node;





public class NullOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new NullOperate();



        return true;
    }
}