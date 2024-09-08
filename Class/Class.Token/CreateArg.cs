namespace Class.Token;

public class CreateArg : Any
{
    public virtual long TokenIndex { get; set; }
    public virtual Array TokenArray { get; set; }
    public virtual long InfoIndex { get; set; }
    public virtual Array InfoArray { get; set; }
    public virtual Data CodeCountData { get; set; }
}