namespace Saber.Node;

public class VarNameCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        VarName node;
        node = (VarName)arg.Node;
        node.Value = (String)k.Field00;
        return true;
    }
}