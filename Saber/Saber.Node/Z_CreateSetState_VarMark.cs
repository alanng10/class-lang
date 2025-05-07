namespace Saber.Node;

public class VarMarkCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        VarMark node;
        node = arg.Node as VarMark;
        node.Var = k.Field00 as VarName;
        return true;
    }
}