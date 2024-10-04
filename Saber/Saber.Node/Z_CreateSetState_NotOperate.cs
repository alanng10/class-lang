namespace Saber.Node;

public class NotOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        NotOperate node;
        node = (NotOperate)arg.Node;
        node.Value = (Operate)k.Field00;
        return true;
    }
}