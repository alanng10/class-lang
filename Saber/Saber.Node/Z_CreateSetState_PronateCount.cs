namespace Saber.Node;

public class PronateCountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        PronateCount node;
        node = (PronateCount)arg.Node;
        return true;
    }
}