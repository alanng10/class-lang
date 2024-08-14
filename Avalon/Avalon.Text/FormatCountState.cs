namespace Avalon.Text;

public class FormatCountState : State
{
    public override bool Init()
    {
        base.Init();
        Value k;
        k = new Value();
        k.Init();
        this.Result = k;
        return true;
    }

    public virtual Write Format { get; set; }
}