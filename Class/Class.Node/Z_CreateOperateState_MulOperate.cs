namespace Class.Node;

public class MulOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        MulOperate node;
        node = (MulOperate)this.Node;
        node.Left = (Operate)this.Arg.Field00;
        node.Right = (Operate)this.Arg.Field01;
        return true;
    }
}