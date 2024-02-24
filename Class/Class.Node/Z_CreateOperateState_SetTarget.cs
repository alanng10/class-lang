namespace Class.Node;

public class SetTargetCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        SetTarget node;
        node = (SetTarget)this.Node;
        node.This = (Operate)this.Arg.Field00;
        node.Field = (FieldName)this.Arg.Field01;

        return true;
    }
}