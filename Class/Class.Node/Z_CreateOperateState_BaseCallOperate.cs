namespace Class.Node;

public class BaseCallOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BaseCallOperate node;
        node = (BaseCallOperate)this.Node;
        node.Maide = (MaideName)this.Arg.Field00;
        node.Argue = (Argue)this.Arg.Field01;
        return true;
    }
}