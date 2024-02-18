namespace Class.Node;





public class VarOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new VarOperate();



        return true;
    }
}