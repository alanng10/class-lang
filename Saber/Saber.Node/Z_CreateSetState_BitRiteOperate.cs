namespace Saber.Node;

public class BitRiteOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.SetArg;

        BitRiteOperate node;
        node = arg.Node as BitRiteOperate;
        node.Value = k.Field00 as Operate;
        node.Count = k.Field01 as Operate;
        return true;
    }
}