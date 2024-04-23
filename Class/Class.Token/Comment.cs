namespace Class.Token;

public class Comment : Any
{
    public virtual int Row { get; set; }
    public virtual InfraRange Range { get; set; }
}