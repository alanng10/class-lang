namespace Saber.Node;

public class BitNotOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        BitNotOperate node;
        node = (BitNotOperate)arg.Node;
        node.Value = (Operate)k.Field00;
        return true;
    }
}