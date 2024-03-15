namespace Class.Node;

public class AddOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        AddOperate node;
        node = (AddOperate)this.Node;
        node.Left = (Operate)this.Arg.Field00;
        node.Right = (Operate)this.Arg.Field01;
        return true;
    }
}