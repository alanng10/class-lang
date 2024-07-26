namespace Class.Node;

public class MaideNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        MaideName node;
        node = (MaideName)this.Node;
        node.Value = (string)arg.Field00;
        return true;
    }
}