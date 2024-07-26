namespace Class.Node;

public class LessOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        LessOperate node;
        node = (LessOperate)this.Node;
        node.Left = (Operate)arg.Field00;
        node.Right = (Operate)arg.Field01;
        return true;
    }
}