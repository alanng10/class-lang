namespace Saber.Node;

public class BoolValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        BoolValue node;
        node = (BoolValue)arg.Node;
        node.Value = k.FieldBool;
        return true;
    }
}