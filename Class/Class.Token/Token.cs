namespace Class.Token;

public class Token : Any
{
    public virtual int Row { get; set; }
    public virtual InfraRange Range { get; set; }
}