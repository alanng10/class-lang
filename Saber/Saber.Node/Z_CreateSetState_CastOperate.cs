namespace Saber.Node;

public class CastOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        CastOperate node;
        node = arg.Node as CastOperate;
        node.Class = k.Field00 as ClassName;
        node.Any = k.Field01 as Operate;
        return true;
    }
}