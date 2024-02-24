namespace Class.Node;

public class ArgueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Argue node;
        node = (Argue)this.Node;
        node.Value = (Array)this.Arg.Field00;

        return true;
    }
}