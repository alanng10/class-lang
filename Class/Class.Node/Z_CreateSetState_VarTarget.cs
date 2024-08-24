namespace Class.Node;

public class VarTargetCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        VarTarget node;
        node = (VarTarget)arg.Node;
        node.Var = (VarName)k.Field00;
        return true;
    }
}