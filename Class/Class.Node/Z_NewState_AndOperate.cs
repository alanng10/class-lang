namespace Class.Node;





public class AndOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new AndOperate();



        return true;
    }
}