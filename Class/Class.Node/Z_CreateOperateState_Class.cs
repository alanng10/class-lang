namespace Class.Node;

public class ClassCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Class node;
        node = (Class)this.Node;
        node.Name = (ClassName)arg.Field00;
        node.Base = (ClassName)arg.Field01;
        node.Part = (Part)arg.Field02;
        return true;
    }
}