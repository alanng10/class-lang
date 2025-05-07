namespace Saber.Node;

public class IntHexValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        IntHexValue node;
        node = arg.Node as IntHexValue;
        node.Value = k.FieldInt;
        return true;
    }
}