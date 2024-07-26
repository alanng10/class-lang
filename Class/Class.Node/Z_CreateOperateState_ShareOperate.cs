namespace Class.Node;

public class ShareOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        ShareOperate node;
        node = (ShareOperate)this.Node;
        node.Class = (ClassName)arg.Field00;
        return true;
    }
}