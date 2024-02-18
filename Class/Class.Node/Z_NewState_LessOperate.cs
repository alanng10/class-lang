namespace Class.Node;





public class LessOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new LessOperate();



        return true;
    }
}