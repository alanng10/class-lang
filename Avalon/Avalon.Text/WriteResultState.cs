namespace Avalon.Text;

public class WriteResultState : State
{
    public override bool Init()
    {
        base.Init();
        WriteResultArg k;
        k = new WriteResultArg();
        k.Init();
        this.Arg = k;
        return true;
    }

    public virtual Write Format { get; set; }
}