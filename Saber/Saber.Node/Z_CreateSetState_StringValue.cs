namespace Saber.Node;

public class StringValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        StringValue node;
        node = (StringValue)arg.Node;
        node.Value = (String)k.Field00;
        return true;
    }
}