namespace Class.Node;

public class ShareOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        ShareOperate node;
        node = (ShareOperate)this.Node;
        node.Class = (ClassName)this.Arg.Field00;
        return true;
    }
}