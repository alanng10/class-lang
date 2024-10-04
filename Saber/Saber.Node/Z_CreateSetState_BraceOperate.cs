namespace Saber.Node;

public class BraceOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        BraceOperate node;
        node = (BraceOperate)arg.Node;
        node.Any = (Operate)k.Field00;
        return true;
    }
}