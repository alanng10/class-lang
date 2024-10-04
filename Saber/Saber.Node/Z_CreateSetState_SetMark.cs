namespace Saber.Node;

public class SetMarkCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        SetMark node;
        node = (SetMark)arg.Node;
        node.This = (Operate)k.Field00;
        node.Field = (FieldName)k.Field01;
        return true;
    }
}