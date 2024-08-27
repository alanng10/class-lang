namespace Avalon.Infra;

public class State : Any
{
    public virtual object Arg { get; set; }
    public virtual object Result { get; set; }

    public virtual bool Execute()
    {
        return true;
    }
}