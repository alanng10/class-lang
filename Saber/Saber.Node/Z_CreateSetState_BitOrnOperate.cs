namespace Saber.Node;

public class BitOrnOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        BitOrnOperate node;
        node = arg.Node as BitOrnOperate;
        node.Lite = k.Field00 as Operate;
        node.Rite = k.Field01 as Operate;
        return true;
    }
}