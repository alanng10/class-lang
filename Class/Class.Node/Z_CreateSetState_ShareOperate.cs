namespace Class.Node;

public class ShareOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        ShareOperate node;
        node = (ShareOperate)arg.Node;
        node.Class = (ClassName)k.Field00;
        return true;
    }
}