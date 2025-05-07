namespace Saber.Node;

public class GetOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        GetOperate node;
        node = arg.Node as GetOperate;
        node.This = k.Field00 as Operate;
        node.Field = k.Field01 as FieldName;
        return true;
    }
}