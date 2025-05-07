namespace Saber.Node;

public class BitAndOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        BitAndOperate node;
        node = arg.Node as BitAndOperate;
        node.Lite = k.Field00 as Operate;
        node.Rite = k.Field01 as Operate;
        return true;
    }
}