namespace Class.Node;

public class ClassNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        ClassName node;
        node = (ClassName)this.Node;
        node.Value = (String)arg.Field00;
        return true;
    }
}