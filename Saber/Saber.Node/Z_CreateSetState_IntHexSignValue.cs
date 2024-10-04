namespace Saber.Node;

public class IntHexSignValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        IntHexSignValue node;
        node = (IntHexSignValue)arg.Node;
        node.Value = k.FieldInt;
        return true;
    }
}