namespace Saber.Node;

public class SignMulOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        SignMulOperate node;
        node = arg.Node as SignMulOperate;
        node.Lite = k.Field00 as Operate;
        node.Rite = k.Field01 as Operate;
        return true;
    }
}