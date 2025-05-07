namespace Saber.Node;

public class BitSignRiteOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        BitSignRiteOperate node;
        node = arg.Node as BitSignRiteOperate;
        node.Value = k.Field00 as Operate;
        node.Count = k.Field01 as Operate;
        return true;
    }
}