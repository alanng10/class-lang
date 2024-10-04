namespace Saber.Node;

public class FieldNameCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        FieldName node;
        node = (FieldName)arg.Node;
        node.Value = (String)k.Field00;
        return true;
    }
}