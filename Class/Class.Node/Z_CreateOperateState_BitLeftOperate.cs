namespace Class.Node;

public class BitLeftOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BitLeftOperate node;
        node = (BitLeftOperate)this.Node;
        node.Value = (Operate)arg.Field00;
        node.Count = (Operate)arg.Field01;
        return true;
    }
}