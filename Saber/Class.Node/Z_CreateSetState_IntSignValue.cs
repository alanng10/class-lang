namespace Class.Node;

public class IntSignValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        IntSignValue node;
        node = (IntSignValue)arg.Node;
        node.Value = k.FieldInt;
        return true;
    }
}