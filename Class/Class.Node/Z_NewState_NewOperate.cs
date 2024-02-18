namespace Class.Node;





public class NewOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new NewOperate();



        return true;
    }
}