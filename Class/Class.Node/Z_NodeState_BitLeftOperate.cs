namespace Class.Node;





public class BitLeftOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteBitLeftOperate(this.Arg);



        return true;
    }
}