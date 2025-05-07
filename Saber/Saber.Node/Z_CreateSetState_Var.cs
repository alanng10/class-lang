namespace Saber.Node;

public class VarCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Var node;
        node = arg.Node as Var;
        node.Class = k.Field00 as ClassName;
        node.Name = k.Field01 as VarName;
        return true;
    }
}