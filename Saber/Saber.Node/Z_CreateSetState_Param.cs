namespace Saber.Node;

public class ParamCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Param node;
        node = arg.Node as Param;
        node.Value = k.Field00 as Array;
        return true;
    }
}