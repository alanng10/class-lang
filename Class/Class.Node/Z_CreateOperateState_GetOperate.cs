namespace Class.Node;

public class GetOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        GetOperate node;
        node = (GetOperate)this.Node;
        node.This = (Operate)this.Arg.Field00;
        node.Field = (FieldName)this.Arg.Field01;
        return true;
    }
}