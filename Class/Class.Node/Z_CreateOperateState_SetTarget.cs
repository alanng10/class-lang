namespace Class.Node;

public class SetTargetCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        SetTarget node;
        node = (SetTarget)this.Node;
        node.This = (Operate)arg.Field00;
        node.Field = (FieldName)arg.Field01;
        return true;
    }
}