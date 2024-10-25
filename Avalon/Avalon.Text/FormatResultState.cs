namespace Avalon.Text;

public class FormatResultState : State
{
    public override bool Init()
    {
        base.Init();
        FormatResultArg k;
        k = new FormatResultArg();
        k.Init();
        this.Arg = k;
        return true;
    }

    public virtual Format Format { get; set; }
}