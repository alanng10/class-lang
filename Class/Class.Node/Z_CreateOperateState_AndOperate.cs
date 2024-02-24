namespace Class.Node;

public class AndOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        AndOperate node;
        node = (AndOperate)this.Node;
        node.Left = (Operate)this.Arg.Field00;
        node.Right = (Operate)this.Arg.Field01;

        return true;
    }
}