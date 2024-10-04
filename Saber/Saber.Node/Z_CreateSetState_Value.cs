namespace Saber.Node;

public class ValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Value node;
        node = (Value)arg.Node;
        return true;
    }
}