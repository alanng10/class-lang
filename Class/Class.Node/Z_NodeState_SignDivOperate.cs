namespace Class.Node;





public class SignDivOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteSignDivOperate(this.Arg);



        return true;
    }
}