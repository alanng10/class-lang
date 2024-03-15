namespace Class.Node;

public class BitLeftOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BitLeftOperate node;
        node = (BitLeftOperate)this.Node;
        node.Value = (Operate)this.Arg.Field00;
        node.Count = (Operate)this.Arg.Field01;
        return true;
    }
}