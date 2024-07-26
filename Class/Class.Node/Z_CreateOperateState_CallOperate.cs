namespace Class.Node;

public class CallOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        CallOperate node;
        node = (CallOperate)this.Node;
        node.This = (Operate)arg.Field00;
        node.Maide = (MaideName)arg.Field01;
        node.Argue = (Argue)arg.Field02;
        return true;
    }
}