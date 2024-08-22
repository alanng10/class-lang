namespace Class.Node;

public class AddOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        AddOperate node;
        node = (AddOperate)this.Node;
        node.Lite = (Operate)arg.Field00;
        node.Rite = (Operate)arg.Field01;
        return true;
    }
}