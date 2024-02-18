namespace Class.Node;





public class BitNotOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBitNotOperate(this.Arg);



        return true;
    }
}