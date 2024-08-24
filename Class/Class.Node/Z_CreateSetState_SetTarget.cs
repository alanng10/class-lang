namespace Class.Node;

public class SetTargetCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        SetTarget node;
        node = (SetTarget)arg.Node;
        node.This = (Operate)k.Field00;
        node.Field = (FieldName)k.Field01;
        return true;
    }
}