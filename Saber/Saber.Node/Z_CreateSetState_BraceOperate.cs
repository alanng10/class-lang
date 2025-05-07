namespace Saber.Node;

public class BraceOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        BraceOperate node;
        node = arg.Node as BraceOperate;
        node.Any = k.Field00 as Operate;
        return true;
    }
}