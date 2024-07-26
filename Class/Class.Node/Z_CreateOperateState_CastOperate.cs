namespace Class.Node;

public class CastOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        CastOperate node;
        node = (CastOperate)this.Node;
        node.Class = (ClassName)arg.Field00;
        node.Any = (Operate)arg.Field01;
        return true;
    }
}