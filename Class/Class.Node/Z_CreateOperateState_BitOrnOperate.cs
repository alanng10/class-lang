namespace Class.Node;

public class BitOrnOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BitOrnOperate node;
        node = (BitOrnOperate)this.Node;
        node.Left = (Operate)this.Arg.Field00;


        node.Right = (Operate)this.Arg.Field01;

        return true;
    }
}