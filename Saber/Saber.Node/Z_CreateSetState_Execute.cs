namespace Saber.Node;

public class ExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Execute node;
        node = (Execute)arg.Node;
        return true;
    }
}