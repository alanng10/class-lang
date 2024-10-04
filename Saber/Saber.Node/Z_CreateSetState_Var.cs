namespace Saber.Node;

public class VarCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Var node;
        node = (Var)arg.Node;
        node.Class = (ClassName)k.Field00;
        node.Name = (VarName)k.Field01;
        return true;
    }
}