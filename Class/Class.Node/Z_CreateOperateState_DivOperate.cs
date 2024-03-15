namespace Class.Node;

public class DivOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        DivOperate node;
        node = (DivOperate)this.Node;
        node.Left = (Operate)this.Arg.Field00;
        node.Right = (Operate)this.Arg.Field01;
        return true;
    }
}