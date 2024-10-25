namespace Avalon.Text;

public class FormatResultState : State
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

    public virtual Format Format { get; set; }
}