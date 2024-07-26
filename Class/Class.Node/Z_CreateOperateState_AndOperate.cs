namespace Class.Node;

public class AndOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        AndOperate node;
        node = (AndOperate)this.Node;
        node.Left = (Operate)arg.Field00;
        node.Right = (Operate)arg.Field01;
        return true;
    }
}