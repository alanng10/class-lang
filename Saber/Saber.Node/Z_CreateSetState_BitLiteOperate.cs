namespace Saber.Node;

public class BitLiteOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.SetArg;

        BitLiteOperate node;
        node = arg.Node as BitLiteOperate;
        node.Value = k.Field00 as Operate;
        node.Count = k.Field01 as Operate;
        return true;
    }
}