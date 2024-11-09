namespace Saber.Token;

public class Comment : Any
{
    public virtual long Row { get; set; }
    public virtual Range Range { get; set; }
}