namespace Class.Node;

public class CallOperateCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        CallOperate node;
        node = (CallOperate)arg.Node;
        node.This = (Operate)k.Field00;
        node.Maide = (MaideName)k.Field01;
        node.Argue = (Argue)k.Field02;
        return true;
    }
}