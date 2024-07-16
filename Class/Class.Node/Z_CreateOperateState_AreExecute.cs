namespace Class.Node;

public class AreExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        AreExecute node;
        node = (AreExecute)this.Node;
        node.Target = (Target)this.Arg.Field00;
        node.Value = (Operate)this.Arg.Field01;
        return true;
    }
}