namespace Saber.Node;

public class VarNameCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        VarName node;
        node = arg.Node as VarName;
        node.Value = k.Field00 as String;
        return true;
    }
}