namespace Saber.Token;

public class CreateArg : Any
{
    public virtual long TokenIndex { get; set; }
    public virtual Array TokenArray { get; set; }
    public virtual long CommentIndex { get; set; }
    public virtual Array InfoArray { get; set; }
    public virtual Data CodeCountData { get; set; }
}