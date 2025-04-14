namespace Saber.Node;

public class NotOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.SetArg;

        NotOperate node;
        node = arg.Node as NotOperate;
        node.Value = k.Field00 as Operate;
        return true;
    }
}