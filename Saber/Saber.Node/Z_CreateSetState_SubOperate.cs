namespace Saber.Node;

public class SubOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        SubOperate node;
        node = (SubOperate)arg.Node;
        node.Lite = (Operate)k.Field00;
        node.Rite = (Operate)k.Field01;
        return true;
    }
}