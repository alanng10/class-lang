namespace Class.Node;

public class MaideNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        MaideName node;
        node = (MaideName)this.Node;
        node.Value = (string)this.Arg.Field00;
        return true;
    }
}