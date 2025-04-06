namespace Saber.Infra;

public class Create : TextAdd
{
    public virtual Stage Stage { get; set; }

    public virtual bool Execute()
    {
        return true;
    }
}