namespace Class.Node;

public class CompCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Comp node;
        node = (Comp)this.Node;
        return true;
    }
}