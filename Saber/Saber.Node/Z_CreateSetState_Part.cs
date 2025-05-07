namespace Saber.Node;

public class PartCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Part node;
        node = arg.Node as Part;
        node.Value = k.Field00 as Array;
        return true;
    }
}