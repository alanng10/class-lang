namespace Class.Node;

public class BitRightOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BitRightOperate node;
        node = (BitRightOperate)this.Node;
        node.Value = (Operate)this.Arg.Field00;
        node.Count = (Operate)this.Arg.Field01;
        return true;
    }
}