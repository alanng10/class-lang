namespace Class.Node;

public class NotOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        NotOperate node;
        node = (NotOperate)this.Node;
        node.Value = (Operate)arg.Field00;
        return true;
    }
}