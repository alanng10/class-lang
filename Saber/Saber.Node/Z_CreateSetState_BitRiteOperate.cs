namespace Saber.Node;

public class BitRiteOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        BitRiteOperate node;
        node = (BitRiteOperate)arg.Node;
        node.Value = (Operate)k.Field00;
        node.Count = (Operate)k.Field01;
        return true;
    }
}