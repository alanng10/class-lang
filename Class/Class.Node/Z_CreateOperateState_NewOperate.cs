namespace Class.Node;

public class NewOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        NewOperate node;
        node = (NewOperate)this.Node;
        node.Class = (ClassName)arg.Field00;
        return true;
    }
}