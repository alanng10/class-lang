namespace Saber.Node;

public class DivOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        DivOperate node;
        node = arg.Node as DivOperate;
        node.Lite = k.Field00 as Operate;
        node.Rite = k.Field01 as Operate;
        return true;
    }
}