namespace Saber.Node;

public class FieldNameCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        FieldName node;
        node = arg.Node as FieldName;
        node.Value = k.Field00 as String;
        return true;
    }
}