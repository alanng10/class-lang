namespace Saber.Node;

public class MulOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        MulOperate node;
        node = arg.Node as MulOperate;
        node.Lite = k.Field00 as Operate;
        node.Rite = k.Field01 as Operate;
        return true;
    }
}