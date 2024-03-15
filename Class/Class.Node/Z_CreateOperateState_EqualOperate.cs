namespace Class.Node;

public class EqualOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        EqualOperate node;
        node = (EqualOperate)this.Node;
        node.Left = (Operate)this.Arg.Field00;
        node.Right = (Operate)this.Arg.Field01;
        return true;
    }
}