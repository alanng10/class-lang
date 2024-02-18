namespace Class.Node;





public class NotOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new NotOperate();



        return true;
    }
}