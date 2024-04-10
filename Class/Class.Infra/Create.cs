namespace Class.Infra;

public class Create : Any
{
    public virtual Stage Stage { get; set; }

    public virtual bool Execute()
    {
        return true;
    }
}