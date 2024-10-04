namespace Saber.Node;

public class VarOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        VarOperate node;
        node = (VarOperate)arg.Node;
        node.Var = (VarName)k.Field00;
        return true;
    }
}