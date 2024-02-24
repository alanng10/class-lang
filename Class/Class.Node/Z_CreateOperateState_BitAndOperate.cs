namespace Class.Node;

public class BitAndOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BitAndOperate node;
        node = (BitAndOperate)this.Node;
        node.Left = (Operate)this.Arg.Field00;
        node.Right = (Operate)this.Arg.Field01;

        return true;
    }
}