namespace Class.Node;

public class TargetCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Target node;
        node = (Target)arg.Node;
        return true;
    }
}