namespace Saber.Node;

public class DivOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        DivOperate node;
        node = (DivOperate)arg.Node;
        node.Lite = (Operate)k.Field00;
        node.Rite = (Operate)k.Field01;
        return true;
    }
}