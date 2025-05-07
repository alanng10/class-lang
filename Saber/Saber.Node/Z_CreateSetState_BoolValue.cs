namespace Saber.Node;

public class BoolValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        BoolValue node;
        node = arg.Node as BoolValue;
        node.Value = k.FieldBool;
        return true;
    }
}