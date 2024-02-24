namespace Class.Node;

public class CastOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CastOperate node;
        node = (CastOperate)this.Node;
        node.Class = (ClassName)this.Arg.Field00;
        node.Any = (Operate)this.Arg.Field01;

        return true;
    }
}