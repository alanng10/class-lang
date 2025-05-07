namespace Saber.Node;

public class ValueCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Value node;
        node = arg.Node as Value;
        return true;
    }
}