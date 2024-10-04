namespace Saber.Infra;

public class Create : Base
{
    public virtual Stage Stage { get; set; }

    public virtual bool Execute()
    {
        return true;
    }
}