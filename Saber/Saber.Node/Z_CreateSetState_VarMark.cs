namespace Saber.Node;

public class VarMarkCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        VarMark node;
        node = (VarMark)arg.Node;
        node.Var = (VarName)k.Field00;
        return true;
    }
}