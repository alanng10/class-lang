namespace Saber.Node;

public class BitAndOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        BitAndOperate node;
        node = (BitAndOperate)arg.Node;
        node.Lite = (Operate)k.Field00;
        node.Rite = (Operate)k.Field01;
        return true;
    }
}