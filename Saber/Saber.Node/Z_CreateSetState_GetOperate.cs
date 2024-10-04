namespace Saber.Node;

public class GetOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        GetOperate node;
        node = (GetOperate)arg.Node;
        node.This = (Operate)k.Field00;
        node.Field = (FieldName)k.Field01;
        return true;
    }
}