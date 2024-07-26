namespace Class.Node;

public class AreExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        AreExecute node;
        node = (AreExecute)this.Node;
        node.Target = (Target)arg.Field00;
        node.Value = (Operate)arg.Field01;
        return true;
    }
}