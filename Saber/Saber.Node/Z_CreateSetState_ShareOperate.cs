namespace Saber.Node;

public class ShareOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        ShareOperate node;
        node = arg.Node as ShareOperate;
        node.Class = k.Field00 as ClassName;
        return true;
    }
}