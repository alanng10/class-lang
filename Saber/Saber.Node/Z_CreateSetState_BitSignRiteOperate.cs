namespace Saber.Node;

public class BitSignRiteOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        BitSignRiteOperate node;
        node = (BitSignRiteOperate)arg.Node;
        node.Value = (Operate)k.Field00;
        node.Count = (Operate)k.Field01;
        return true;
    }
}