namespace Class.Node;





public class BracketOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new BracketOperate();



        return true;
    }
}