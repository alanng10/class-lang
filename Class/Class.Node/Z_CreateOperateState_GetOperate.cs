namespace Class.Node;

public class GetOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        GetOperate node;
        node = (GetOperate)this.Node;
        node.This = (Operate)arg.Field00;
        node.Field = (FieldName)arg.Field01;
        return true;
    }
}