namespace Class.Node;





public class ThisOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ThisOperate();



        return true;
    }
}