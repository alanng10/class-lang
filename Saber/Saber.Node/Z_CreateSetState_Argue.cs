namespace Saber.Node;

public class ArgueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.SetArg;

        Argue node;
        node = arg.Node as Argue;
        node.Value = k.Field00 as Array;
        return true;
    }
}