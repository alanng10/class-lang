namespace Saber.Node;

public class VarOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        VarOperate node;
        node = arg.Node as VarOperate;
        node.Var = k.Field00 as VarName;
        return true;
    }
}