namespace Saber.Node;

public class CallOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        CallOperate node;
        node = arg.Node as CallOperate;
        node.This = k.Field00 as Operate;
        node.Maide = k.Field01 as MaideName;
        node.Argue = k.Field02 as Argue;
        return true;
    }
}