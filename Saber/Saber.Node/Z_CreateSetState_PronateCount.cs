namespace Saber.Node;

public class PronateCountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        PronateCount node;
        node = arg.Node as PronateCount;
        return true;
    }
}