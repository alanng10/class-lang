namespace Saber.Node;

public class IntHexSignValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        IntHexSignValue node;
        node = arg.Node as IntHexSignValue;
        node.Value = k.FieldInt;
        return true;
    }
}