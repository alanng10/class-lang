namespace Saber.Node;

public class IntSignValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        IntSignValue node;
        node = arg.Node as IntSignValue;
        node.Value = k.FieldInt;
        return true;
    }
}