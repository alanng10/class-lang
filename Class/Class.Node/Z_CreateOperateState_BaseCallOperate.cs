namespace Class.Node;

public class BaseCallOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BaseCallOperate node;
        node = (BaseCallOperate)this.Node;
        node.Maide = (MaideName)arg.Field00;
        node.Argue = (Argue)arg.Field01;
        return true;
    }
}