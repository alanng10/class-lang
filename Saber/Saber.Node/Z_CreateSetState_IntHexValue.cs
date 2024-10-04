namespace Saber.Node;

public class IntHexValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        IntHexValue node;
        node = (IntHexValue)arg.Node;
        node.Value = k.FieldInt;
        return true;
    }
}