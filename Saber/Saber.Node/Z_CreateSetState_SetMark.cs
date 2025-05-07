namespace Saber.Node;

public class SetMarkCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        SetMark node;
        node = arg.Node as SetMark;
        node.This = k.Field00 as Operate;
        node.Field = k.Field01 as FieldName;
        return true;
    }
}