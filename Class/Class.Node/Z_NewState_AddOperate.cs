namespace Class.Node;





public class AddOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new AddOperate();



        return true;
    }
}