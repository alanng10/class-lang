namespace Class.Node;





public class SignMulOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteSignMulOperate(this.Arg);



        return true;
    }
}