namespace Class.Node;

public class SignLessOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        SignLessOperate node;
        node = (SignLessOperate)this.Node;
        node.Left = (Operate)arg.Field00;
        node.Right = (Operate)arg.Field01;
        return true;
    }
}