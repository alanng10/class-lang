namespace Class.Node;

public class ClassCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Class node;
        node = (Class)this.Node;
        node.Name = (ClassName)this.Arg.Field00;
        node.Base = (ClassName)this.Arg.Field01;
        node.Member = (Part)this.Arg.Field02;

        return true;
    }
}