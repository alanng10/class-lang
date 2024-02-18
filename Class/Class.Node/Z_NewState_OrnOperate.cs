namespace Class.Node;





public class OrnOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new OrnOperate();



        return true;
    }
}