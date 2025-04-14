namespace Saber.Node;

public class BitNotOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.SetArg;

        BitNotOperate node;
        node = arg.Node as BitNotOperate;
        node.Value = k.Field00 as Operate;
        return true;
    }
}